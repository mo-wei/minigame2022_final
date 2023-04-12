using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SeaPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/SeaPanel";
    PanelManager panelManager = new PanelManager();
    public SeaPanel() : base(new UIType(path)) { }

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
            Color color = UITool.GetOrAddComponentInChildren<Button>("Music").gameObject.GetComponent<Image>().color;
            if(color.r == 0.75f)
            {
                UITool.GetOrAddComponentInChildren<Button>("Music").gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f);
            }
            else
            {
                UITool.GetOrAddComponentInChildren<Button>("Music").gameObject.GetComponent<Image>().color = new Color(0.75f, 0.75f, 0.75f);
            }
            });
    }


}
