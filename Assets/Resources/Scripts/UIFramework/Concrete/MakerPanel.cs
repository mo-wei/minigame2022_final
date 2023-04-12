using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakerPanel : BasePanel
{

    static readonly string path = "Prefabs/UI/Panel/MakerPanel";
    PanelManager panelManager = new PanelManager();
    public MakerPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("MakerClose").onClick.AddListener(() =>
        {
            //����¼��������������
            panelManager.Pop();
        });

    }


}
