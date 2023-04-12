using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 开始主面板
/// </summary>
public class StartPanel : BasePanel
{

    static readonly string path = "Prefabs/UI/Panel/StartPanel";
    PanelManager panelManager=new PanelManager();
    public StartPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        /*
        UITool.GetOrAddComponentInChildren<Button>("").onClick.AddListener(() =>
        {
            //点击事件可以添加在这里
            PanelManager.Push(new SettingPanel());//推出新界面
            PanelManager.Pop();  //关闭当前界面
        });
        */
        UITool.GetOrAddComponentInChildren<Button>("StartGame").onClick.AddListener(() =>
        {
            //点击事件可以添加在这里
            GameRoot.Instance.SceneSystem.SetScene(new MainScene());
        });
        UITool.GetOrAddComponentInChildren<Button>("MakerButton").onClick.AddListener(() =>
        {
            //点击事件可以添加在这里
            panelManager.Push(new MakerPanel());
        });
        UITool.GetOrAddComponentInChildren<Button>("GameClose").onClick.AddListener(() =>
        {
            //点击事件可以添加在这里
            Application.Quit();
        });


    }
}
