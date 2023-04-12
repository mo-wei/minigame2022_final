using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// ����ȫ�ֵĶ���
/// </summary>
public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance { get; private set; }

    /// <summary>
    /// ����������
    /// </summary>
    public SceneSystem SceneSystem { get; private set; }

    /// <summary>
    /// ��ʾ�ڿ�������
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
