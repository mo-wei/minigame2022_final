using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ������״̬����ϵͳ
/// </summary>
public class SceneSystem
{
    /// <summary>
    /// ����״̬��
    /// </summary>
    SceneState sceneState;


    /// <summary>
    /// ���õ�ǰ���������뵱ǰ����
    /// </summary>
    /// <param name="state"></param>
    public void SetScene(SceneState state) 
    {
        if (sceneState != null)
            sceneState.OnExit();
        sceneState=state;
        if(sceneState != null)
            state.OnEnter();
    }
}
