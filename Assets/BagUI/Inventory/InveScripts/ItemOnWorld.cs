using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;

    public string ID; 

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("000");
        if(other.gameObject.CompareTag("Player")==true)         //�����Player����
        {
            AudioManager.instance.PickAudio();
            //Debug.Log("111");
            AddNewItem();                                       //���б����������Ŀ
            if(ID == "DoubleJump")
            {
                PlayerControl.instance.IsDoubleJumpEnable = true;
                PlayerControl.instance.JumpTimes = 2;
            }
            if(ID == "SeePlatform")
            {
                GameManager.instance.SeePlatforms();
                GameManager.instance.IsSeeGet = true;
            }
            if(ID == "Dash")
            {
                PlayerControl.instance.IsDashEnable = true;
            }
            if(ID == "Seed")
            {
                GameManager.instance.IsSeedGet = true;
            }
            if(ID == "Power")
            {
                GameManager.instance.IsPowerGet = true;
                GameManager.instance.ClearGrass();
            }
            Destroy(gameObject);                                //�������屾��

        }
    }


    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))       //�������������б��ﲻ����
        {
            playerInventory.itemList.Add(thisItem);             //����������
            InventoryManager.CreateNewItem(thisItem);           //�ڱ�����������Ҳ����
        }
        /* ��ͬһ������Ĳ�ͬ����
        else                                                    //��ͬһ�����岻ͬ�����õ�
        {
            thisItem.itemHeld += 1;
        }
        */

        //InventoryManager.RefreshItem();                       //��ͬ�����õ�
    }
    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, 0.1f * Mathf.Sin(Time.time) * Time.deltaTime, 0);
    }
}
