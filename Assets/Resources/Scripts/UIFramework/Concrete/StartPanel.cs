using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��ʼ�����
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
            //����¼��������������
            PanelManager.Push(new SettingPanel());//�Ƴ��½���
            PanelManager.Pop();  //�رյ�ǰ����
        });
        */
        UITool.GetOrAddComponentInChildren<Button>("StartGame").onClick.AddListener(() =>
        {
            //����¼��������������
            GameRoot.Instance.SceneSystem.SetScene(new MainScene());
        });
        UITool.GetOrAddComponentInChildren<Button>("MakerButton").onClick.AddListener(() =>
        {
            //����¼��������������
            panelManager.Push(new MakerPanel());
        });
        UITool.GetOrAddComponentInChildren<Button>("GameClose").onClick.AddListener(() =>
        {
            //����¼��������������
            Application.Quit();
        });


    }
}
