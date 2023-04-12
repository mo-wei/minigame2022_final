using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//所有UI面板的父类，包含UI面板的状态信息
public abstract class BasePanel
{
    //UI信息
    public UIType UIType { get; private set; }
    /// <summary>
    /// UI管理工具
    /// </summary>
    public UITool UITool { get; private set; }


    /// <summary>
    /// 面板管理器
    /// </summary>
    public PanelManager PanelManager { get; private set; }
    /// <summary>
    /// UI管理器
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
    /// 初始化面板管理器
    /// </summary>
    /// <param name="panelManager"></param>
    public void Initialize(PanelManager panelManager)
    {
        panelManager = panelManager;
    }


    /// <summary>
    /// 初始化UI管理器
    /// </summary>
    /// <param name="uIManager"></param>
    public void Initialize(UIManager uIManager)
    {
        UIManager = uIManager;
    }


    /// <summary>
    /// 初始化UITool
    /// </summary>
    public virtual void OnEnter() { }




    //UI暂停时执行的操作
    public virtual void OnPause()
    {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = false;
    }


    //UI继续时进行的操作
    public virtual void OnResume()
    {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = true;
    }


    //UI退出时执行的操作
    public virtual void OnExit()
    {
        UIManager.DestroyUI(UIType);
    }

    //简化显示
    public void Push(BasePanel panel)=>PanelManager?.Push(panel);


    //简化消失
    public void Pop()=>PanelManager?.Pop();

}
