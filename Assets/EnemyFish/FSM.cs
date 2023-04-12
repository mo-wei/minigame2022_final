using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.InputSystem;

//״̬ö��
public enum StateType
{
    Idle,
    Chase,
    Hit,
    Attack
}

//�����б�
[Serializable]
public class Parameter
{
    public float chaseSpeed;//׷���ٶ�
    public float chaseRadius;//׷�ٰ뾶
    public Transform target;//׷��Ŀ��
    public Transform campPosition;//Ӫ������
    public float VigilanceValue;//����ֵ
    public float currentVigilValue;//��ǰ�ľ���ֵ
    public CircleCollider2D camp;//Ӫ�ص���ײ��
    public Animator animator;//������
    public float IdleSpeed;
    public AIPath AI;
    public AIDestinationSetter AIPathFindingSetter;
    public Transform parent;
    public Transform[] patrolPoints;
    public bool isBigFish;
    public float distance;
}


//״̬��
public class FSM : MonoBehaviour
{
    //��ǰ״̬
    public Istate currentState;
    public Dictionary<StateType, Istate> states = new Dictionary<StateType, Istate>();

    public Parameter parameter;

    private void Awake()
    {
        //��ʼ��״̬�ֵ�
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Chase, new ChaseState(this));
        states.Add(StateType.Hit, new HitState(this));
        states.Add(StateType.Attack, new AttackState(this));

        parameter.animator = GetComponent<Animator>();
        //��¼�������λ��
        parameter.camp = this.transform.parent.parent.GetComponentInChildren<CircleCollider2D>();
        parameter.camp.radius = parameter.chaseRadius;
        parameter.campPosition = parameter.camp.transform;
        parameter.target = parameter.campPosition;
        //Ѱ·���
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
            parameter.currentVigilValue -= 0.5f * Time.deltaTime;//�ٶȿ��Ը��ģ�֮��������
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

