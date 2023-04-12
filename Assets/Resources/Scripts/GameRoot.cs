using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// 管理全局的东西
/// </summary>
public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance { get; private set; }

    /// <summary>
    /// 场景管理器
    /// </summary>
    public SceneSystem SceneSystem { get; private set; }

    /// <summary>
    /// 显示在框架外可用
    /// </summary>
    public UnityAction<BasePanel> Push { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        SceneSystem = new SceneSystem();
        DontDestroyOnLoad(this.gameObject);
    }
    /*
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        Instance=this;
        SceneSystem=new SceneSystem();

        DontDestroyOnLoad(gameObject);
    }
    */
    private void Start()
    {
        SceneSystem.SetScene(new StartScene());
    }

    public void SetAction(UnityAction<BasePanel> push)
    {
        Push=push;
    }
}
