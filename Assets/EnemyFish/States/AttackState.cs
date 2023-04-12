using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : Istate
{
    private FSM manager;
    private Parameter parameter;
    private float speed;
    private float dashTime;
    private Vector3 faceDirection;
    public AttackState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
        speed = 2f;
    }

    public void OnEnter()
    {
        parameter.AI.canMove = false;
        dashTime = 2f;
        faceDirection = parameter.target.position - manager.transform.position;
        
    }

    public void OnExit()
    {
        dashTime = 0f;
    }

    public void OnUpdate()
    {
        if(dashTime > 0f)
        {
            parameter.parent.Translate(faceDirection * speed * Time.deltaTime);
            dashTime -= Time.deltaTime;
        }
        else
        {
            if(parameter.currentVigilValue <= 0)
            {
                manager.TranslateState(StateType.Idle);
            }
            else
            {
                manager.TranslateState(StateType.Chase);
            }
        }
    }
}
