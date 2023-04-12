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

    public static void CreateNewItem(Item item)      //没有物体时，在背包里创建新的
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position,Quaternion.identity );         //在背包里创建新物体的实例，这个物体是事先预置好的
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);                                                //新物体的坐标是父位置的预定
        newItem.slotItem = item;                                                                                            //背包里的项目是传进来的项目
        newItem.slotImage.sprite = item.itemImage;                                                                          //背包里的图像是传进来项目的图片
        //newItem.slotText = item.itemInfo;
        //newItem.slotNum.text = item.itemHeld.ToString();                                                                  //背包里一个物体的多个数量
    }

    /*
    private void OnEnable()                                                                                                 //有这个物体时，增加数量
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
