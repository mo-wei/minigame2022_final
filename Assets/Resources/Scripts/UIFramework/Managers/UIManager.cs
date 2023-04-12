using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//�洢����UI��Ϣ�����ҿ��Դ洢������UI
public class UIManager
{

    //�洢����UI����Ϣ�ֵ䣬ÿһ��UI��Ϣ�����Ӧһ��GameObj
    private Dictionary<UIType, GameObject> dicUI;


    public UIManager()
    {
        dicUI=new Dictionary<UIType, GameObject>();
    }

    /// <summary>
    /// ���һ��UI����
    /// </summary>
    /// <param name="type">UI��Ϣ</param>
    /// <returns></returns>
    public GameObject GetSingleUI(UIType type)
    {
        GameObject parent =GameObject.Find("Canvas");
        if (!parent)
        {
            Debug.LogError("Canvas�����ڣ�����ϸ����");
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
    /// ����һ��UI�Ķ���
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
