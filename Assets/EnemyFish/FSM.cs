using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.InputSystem;

//状态枚举
public enum StateType
{
    Idle,
    Chase,
    Hit,
    Attack
}

//属性列表
[Serializable]
public class Parameter
{
    public float chaseSpeed;//追逐速度
    public float chaseRadius;//追踪半径
    public Transform target;//追逐目标
    public Transform campPosition;//营地中心
    public float VigilanceValue;//警觉值
    public float currentVigilValue;//当前的警觉值
    public CircleCollider2D camp;//营地的碰撞器
    public Animator animator;//动画器
    public float IdleSpeed;
    public AIPath AI;
    public AIDestinationSetter AIPathFindingSetter;
    public Transform parent;
    public Transform[] patrolPoints;
    public bool isBigFish;
    public float distance;
}


//状态机
public class FSM : MonoBehaviour
{
    //当前状态
    public Istate currentState;
    public Dictionary<StateType, Istate> states = new Dictionary<StateType, Istate>();

    public Parameter parameter;

    private void Awake()
    {
        //初始化状态字典
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Chase, new ChaseState(this));
        states.Add(StateType.Hit, new HitState(this));
        states.Add(StateType.Attack, new AttackState(this));

        parameter.animator = GetComponent<Animator>();
        //记录好最初的位置
        parameter.camp = this.transform.parent.parent.GetComponentInChildren<CircleCollider2D>();
        parameter.camp.radius = parameter.chaseRadius;
        parameter.campPosition = parameter.camp.transform;
        parameter.target = parameter.campPosition;
        //寻路相关
        parameter.parent = transform.parent;
        parameter.AI = parameter.parent.GetComponent<AIPath>();
        parameter.AIPathFindingSetter = parameter.parent.GetComponent<AIDestinationSetter>();
        TranslateState(StateType.Idle);
    }
    private void Update()
    {
        currentState.OnUpdate();
        this.transform.localPosition = new Vector3(0, 0, 0);
        if (parameter.currentVigilValue > 0)
        {
            parameter.currentVigilValue -= 0.5f * Time.deltaTime;//速度可以更改，之后可以设参
        }
    }

    public void TranslateState(StateType type)
    {
        if (currentState != null)
            currentState.OnExit();
        currentState = states[type];
        currentState.OnEnter();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!parameter.isBigFish)
            {
                collision.gameObject.GetComponent<PlayerControl>().Dead();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            print(55555);
            parameter.currentVigilValue = 0f;
        }
    }

}

