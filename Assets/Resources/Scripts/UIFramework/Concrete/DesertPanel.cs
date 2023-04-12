using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DesertPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/SeaPanel";
    PanelManager panelManager = new PanelManager();
    public DesertPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("Plause").onClick.AddListener(() =>
        {
            //����¼��������������
            panelManager.Pop();
        });
        UITool.GetOrAddComponentInChildren<Button>("Close").onClick.AddListener(() =>
        {
            //����¼��������������
            panelManager.Pop();
        });
        UITool.GetOrAddComponentInChildren<Button>("Home").onClick.AddListener(() =>
        {
            //����¼��������������
            GameRoot.Instance.SceneSystem.SetScene(new StartScene());
        });
        UITool.GetOrAddComponentInChildren<Button>("Music").onClick.AddListener(() =>
        {
            //����¼��������������
            Debug.Log("111");
            UITool.GetOrAddComponentInChildren<Button>("Music").gameObject.GetComponent<Image>().color  = new Color(49f,49f,49f);
            });
    }


}
