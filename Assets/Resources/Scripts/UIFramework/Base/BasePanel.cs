using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//����UI���ĸ��࣬����UI����״̬��Ϣ
public abstract class BasePanel
{
    //UI��Ϣ
    public UIType UIType { get; private set; }
    /// <summary>
    /// UI������
    /// </summary>
    public UITool UITool { get; private set; }


    /// <summary>
    /// ��������
    /// </summary>
    public PanelManager PanelManager { get; private set; }
    /// <summary>
    /// UI������
    /// </summary>
    public UIManager UIManager { get; private set; }


    public BasePanel(UIType uIType)
    {
        UIType = uIType;
    }


    public void Initialize(UITool tool)
    {
        UITool = tool;
    }


    /// <summary>
    /// ��ʼ����������
    /// </summary>
    /// <param name="panelManager"></param>
    public void Initialize(PanelManager panelManager)
    {
        panelManager = panelManager;
    }


    /// <summary>
    /// ��ʼ��UI������
    /// </summary>
    /// <param name="uIManager"></param>
    public void Initialize(UIManager uIManager)
    {
        UIManager = uIManager;
    }


    /// <summary>
    /// ��ʼ��UITool
    /// </summary>
    public virtual void OnEnter() { }




    //UI��ͣʱִ�еĲ���
    public virtual void OnPause()
    {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = false;
    }


    //UI����ʱ���еĲ���
    public virtual void OnResume()
    {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = true;
    }


    //UI�˳�ʱִ�еĲ���
    public virtual void OnExit()
    {
        UIManager.DestroyUI(UIType);
    }

    //����ʾ
    public void Push(BasePanel panel)=>PanelManager?.Push(panel);


    //����ʧ
    public void Pop()=>PanelManager?.Pop();

}
