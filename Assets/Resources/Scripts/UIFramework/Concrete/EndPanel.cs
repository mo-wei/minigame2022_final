using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPanel : BasePanel
{

    static readonly string path = "Prefabs/UI/Panel/EndPanel";
    PanelManager panelManager = new PanelManager();
    public EndPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("End").onClick.AddListener(() =>
        {
            //点击事件可以添加在这里
            Application.Quit();
        });

    }


}

