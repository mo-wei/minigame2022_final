using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : Istate
{
    private FSM manager;
    private Parameter parameter;
    //上一次的位置
    private Vector3 lastFramePos;
    public ChaseState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        parameter.AI.canMove = true;
        parameter.AI.maxSpeed = parameter.chaseSpeed;
    }

    public void OnExit()
    {
    }
    /// <summary>
    /// 保持Idle状态时在家
    /// </summary>
    public void OnUpdate()
    {
        if (parameter.currentVigilValue <= 0f)
        {
            manager.TranslateState(StateType.Idle);
        }
        if(parameter.AI.canMove)
        {
            /*Vector3 faceDirection;
            faceDirection = manager.transform.position - lastFramePos;
            lastFramePos = manager.transform.position;
            float angle = Mathf.Atan2(faceDirection.y, faceDirection.x) * Mathf.Rad2Deg;
            manager.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
        }
        if(parameter.isBigFish)
        {
            if(Vector3.Distance(parameter.target.position, manager.transform.position) > parameter.distance)
            {
                //parameter.AI.maxSpeed = parameter.chaseSpeed;
            }
            else
            {
                parameter.AI.maxSpeed = 0f;
            }
        }

    }


}
