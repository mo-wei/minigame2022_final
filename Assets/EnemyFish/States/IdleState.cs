using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : Istate
{
    private FSM manager;
    private Parameter parameter;
    private Vector3 lastFramePos;
    public IdleState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        parameter.target = parameter.patrolPoints[0];
        parameter.AI.canMove = true;
        parameter.AI.maxSpeed = parameter.IdleSpeed;
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        if(Vector3.Distance(manager.transform.position, parameter.target.position) < 1f)
        {
            parameter.target = parameter.patrolPoints[Random.Range(0, parameter.patrolPoints.Length)];
        }
        /*Vector3 faceDirection;
        faceDirection = manager.transform.position - lastFramePos;
        lastFramePos = manager.transform.position;
        float angle = Mathf.Atan2(faceDirection.y, faceDirection.x) * Mathf.Rad2Deg;
        manager.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
        parameter.AIPathFindingSetter.target = parameter.target;
        if (parameter.currentVigilValue > 0f)
        {
            manager.TranslateState(StateType.Chase);
        }
    }
}
