using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Main����
/// </summary>
public class MainScene :SceneState
{

    /// <summary>
    /// ��������
    /// </summary>
    readonly string sceneName = "Main";
    PanelManager panelManager;
    public override void OnEnter()
    {
        panelManager = new PanelManager();
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            panelManager.Push(new SettingPanel());

        }
    }


    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        //panelManager.PopAll();
    }

    /// <summary>
    /// �����������֮��ִ�еķ���
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="load"></param>
    private void SceneLoaded(Scene scene, LoadSceneMode load)
    {
        panelManager.Push(new SettingPanel());
    }
}

