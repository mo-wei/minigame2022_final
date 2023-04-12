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
        if(other.gameObject.CompareTag("Player")==true)         //如果是Player碰到
        {
            AudioManager.instance.PickAudio();
            //Debug.Log("111");
            AddNewItem();                                       //在列表里添加新项目
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
            Destroy(gameObject);                                //销毁物体本身

        }
    }


    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))       //如果这个东西在列表里不存在
        {
            playerInventory.itemList.Add(thisItem);             //添加这个东西
            InventoryManager.CreateNewItem(thisItem);           //在背包管理器里也加入
        }
        /* 有同一个物体的不同数量
        else                                                    //有同一个物体不同数量用的
        {
            thisItem.itemHeld += 1;
        }
        */

        //InventoryManager.RefreshItem();                       //不同数量用的
    }
    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, 0.1f * Mathf.Sin(Time.time) * Time.deltaTime, 0);
    }
}
