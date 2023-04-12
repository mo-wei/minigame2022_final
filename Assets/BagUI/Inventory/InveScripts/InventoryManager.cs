using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;

    //public Text itemInformation;
    private void Awake()
    {
        if(instance!=null)
            Destroy(this);
        instance = this;
        myBag.itemList.Clear();
    }

    public static void CreateNewItem(Item item)      //û������ʱ���ڱ����ﴴ���µ�
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position,Quaternion.identity );         //�ڱ����ﴴ���������ʵ�����������������Ԥ�úõ�
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);                                                //������������Ǹ�λ�õ�Ԥ��
        newItem.slotItem = item;                                                                                            //���������Ŀ�Ǵ���������Ŀ
        newItem.slotImage.sprite = item.itemImage;                                                                          //�������ͼ���Ǵ�������Ŀ��ͼƬ
        //newItem.slotText = item.itemInfo;
        //newItem.slotNum.text = item.itemHeld.ToString();                                                                  //������һ������Ķ������
    }

    /*
    private void OnEnable()                                                                                                 //���������ʱ����������
    {
        RefreshItem();
    }

    public static void RefreshItem()                    
    {

        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            CreateNewItem(instance.myBag.itemList[i]);
        }
    }
    */
}
