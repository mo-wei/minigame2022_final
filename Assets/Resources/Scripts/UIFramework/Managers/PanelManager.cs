using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;



/// <summary>
/// ������������ջ���洢UI
/// </summary>
public class PanelManager
{
    /// <summary>
    /// �洢UI����ջ
    /// </summary>
    private static Stack<BasePanel> stackPanel;

    /// <summary>
    /// UI������
    /// </summary>
    private UIManager uiManager;
    private BasePanel panel;


    public PanelManager()
    {
        stackPanel=new Stack<BasePanel>();
        uiManager=new UIManager();
    }


    /// <summary>
    /// UI����ջ�������˲�������ʾһ�����
    /// </summary>
    /// <param name="nextPanel">Ҫ��ʾ�����</param>
    public void Push(BasePanel nextPanel)
    {
        if (stackPanel.Count> 0)
        {
            panel=stackPanel.Peek();
            panel.OnPause();

        }
        stackPanel.Push(nextPanel);
        GameObject panelGo=uiManager.GetSingleUI(nextPanel.UIType);

        nextPanel.Initialize(new UITool(panelGo));
        nextPanel.Initialize(this);
        nextPanel.Initialize(uiManager);
        nextPanel.OnEnter();
    }


    /// <summary>
    /// ִ�����ĳ�ջ�������˲�����ִ������onExit����
    /// </summary>
    public void Pop()
    {
        if (stackPanel.Count > 0)
        {
            stackPanel.Peek().OnExit();
            stackPanel.Pop();
        }
        if(stackPanel.Count>0)
            stackPanel.Peek().OnResume();
    }
    /// <summary>
    /// ִ����������OnExit()
    /// </summary>
    /*
    public void PopAll()
    {
        while (stackPanel.Count > 0)
        {
            stackPanel.Pop().OnExit();
        }
            
    }
    */
}
