using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//存储所有UI信息，并且可以存储或销毁UI
public class UIManager
{

    //存储所有UI的信息字典，每一个UI信息都会对应一个GameObj
    private Dictionary<UIType, GameObject> dicUI;


    public UIManager()
    {
        dicUI=new Dictionary<UIType, GameObject>();
    }

    /// <summary>
    /// 获得一个UI对象
    /// </summary>
    /// <param name="type">UI信息</param>
    /// <returns></returns>
    public GameObject GetSingleUI(UIType type)
    {
        GameObject parent =GameObject.Find("Canvas");
        if (!parent)
        {
            Debug.LogError("Canvas不存在，请仔细查找");
            return null;
        }
        if(dicUI.ContainsKey(type))
            return dicUI[type];
        GameObject ui = GameObject.Instantiate(Resources.Load<GameObject>(type.Path),parent.transform);

        ui.name = type.Name;
        dicUI.Add(type, ui);
        return ui;
    }



    /// <summary>
    /// 销毁一个UI的对象
    /// </summary>
    /// <param name="type"></param>
    public void DestroyUI(UIType type) 
    {
        if (dicUI.ContainsKey(type))
        {
            GameObject.Destroy(dicUI[type]);
            dicUI.Remove(type);
        }
    }
}
