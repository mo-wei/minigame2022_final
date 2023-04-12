using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// UI�����ߣ�������ȡĳ���Ӷ�������Ĳ���
/// </summary>
public class UITool
{

    /// <summary>
    /// ��ǰ�Ļ���
    /// </summary>
    GameObject activePanel;

    public UITool(GameObject panel)
    {
        activePanel = panel;
    }


    /// <summary>
    /// ����ǰ�Ļ����ȡ�������һ�����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetOrAddComponent<T>() where T : Component
    { 
        if(activePanel.GetComponent<T>()==null)
            activePanel.AddComponent<T>();


        return activePanel.GetComponent<T>();
    }

    /// <summary>
    /// �������Ʋ���һ���Ӷ�������
    /// </summary>
    /// <param name="name">�Ӷ�������</param>
    /// <returns></returns>
    public GameObject FindChildGameObject(string name)
    {
        Transform[] trans =activePanel.GetComponentsInChildren<Transform>();

        foreach (Transform item in trans)
        {
            if (item.name==name)
            {
                return item.gameObject;
            }
        }
        Debug.LogWarning($"{activePanel.name}���Ҳ�����Ϊ{name}���Ӷ���");
        return null;
    }

    /// <summary>
    /// �������ƻ�ȡһ���Ӷ�������
    /// </summary>
    /// <typeparam name="T">�������</typeparam>
    /// <param name="name">�Ӷ��������</param>
    /// <returns></returns>
    public T GetOrAddComponentInChildren<T>(string name) where T : Component
    {
        GameObject child=FindChildGameObject(name);
        if (child)
        {
            if (child.GetComponent<T>() == null)
                child.AddComponent<T>();

            return child.GetComponent<T>();
        }
        return null;
    }
}
