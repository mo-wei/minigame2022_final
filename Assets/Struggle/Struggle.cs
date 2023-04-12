using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// ����ű�����Player�����ϣ�Ҫ��Player�������ж������if(!Struggle);
/// ������ס������Ҫ���ϡ�Rock����tag;
/// </summary>
public class Struggle : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform trans;
    public bool isStruggle=false;
    public float STime;                     //��ץס��Ĳ�����ֻ�ȴ���ʱ�䣬��λs
    private float struTime;                //��stime��
    private Vector2 hitPos;                 //��ײ��
    private Vector2 RockCenter;
    public float speed=3;
    public float BackTime = 1;              //��ס�󵯻ص�ʱ��
    public float subTime = 1;               //������������ʱ��
    public InputAction StruggleInput;
    public int Count = 0;

    Vector2 InVelocity;
    private void Awake()
    {
        StruggleInput.performed += callback =>
        {
            if(isStruggle)
                Count += 1;
        };
    }
    private void OnEnable()
    {
        StruggleInput.Enable();
    }
    private void OnDisable()
    {
        StruggleInput.Disable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        struTime = STime;

    }

    void Update()
    {
        if (isStruggle)
        {
            rb.velocity = new Vector2(0,0);
            if (Count >= 10)
            {
                rb.velocity = -InVelocity * speed;
                BackTime = 1;
                this.GetComponent<Animator>().Play("swim_left");
                isStruggle = false;
                struTime = STime;
                Count = 0;
                StartCoroutine("startCountDown");
            }





            //��������ʱ��ץסһ��ʱ�䵯��
            struTime-=Time.deltaTime;
            if (struTime <= 0)
            {
                rb.velocity = -InVelocity * speed;
                BackTime = 1;
                this.GetComponent<Animator>().Play("swim_left");
                isStruggle = false;
                struTime = STime;
                Count = 0;
                StartCoroutine("startCountDown");
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
    }
    public IEnumerator startCountDown()
    {
        yield return new WaitForSeconds(0.1f);
        rb.velocity = new Vector2(0, 0);
        gameObject.GetComponent<PlayerControl>().IsStop = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            this.GetComponent<Animator>().Play("sand");
            RockCenter = collision.transform.position;
            isStruggle = true;
            gameObject.GetComponent<PlayerControl>().IsStop = true;
            InVelocity = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        }
    }
}
