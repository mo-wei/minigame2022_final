using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/SettingPanel";
    PanelManager panelManager = new PanelManager();
    public SettingPanel(): base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("Set").onClick.AddListener(() =>
        {
            //����¼��������������
            //if()
                panelManager.Push(new SeaPanel());
            //else
              // panelManager.Push(new DesertPanel());
                

        }
        );
    }


}
