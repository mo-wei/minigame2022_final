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
            //点击事件可以添加在这里
            panelManager.Pop();
        });
        UITool.GetOrAddComponentInChildren<Button>("Close").onClick.AddListener(() =>
        {
            //点击事件可以添加在这里
            panelManager.Pop();
        });
        UITool.GetOrAddComponentInChildren<Button>("Home").onClick.AddListener(() =>
        {
            //点击事件可以添加在这里
            GameRoot.Instance.SceneSystem.SetScene(new StartScene());
        });
        UITool.GetOrAddComponentInChildren<Button>("Music").onClick.AddListener(() =>
        {
            //点击事件可以添加在这里
            Debug.Log("111");
            UITool.GetOrAddComponentInChildren<Button>("Music").gameObject.GetComponent<Image>().color  = new Color(49f,49f,49f);
            });
    }


}
