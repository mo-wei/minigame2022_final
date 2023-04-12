using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 这个脚本挂在Player的身上，要给Player的其他行动外加上if(!Struggle);
/// 对于困住的土块要打上“Rock”的tag;
/// </summary>
public class Struggle : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform trans;
    public bool isStruggle=false;
    public float STime;                     //被抓住后的不挣扎只等待的时间，单位s
    private float struTime;                //存stime的
    private Vector2 hitPos;                 //碰撞点
    private Vector2 RockCenter;
    public float speed=3;
    public float BackTime = 1;              //困住后弹回的时间
    public float subTime = 1;               //挣扎按键－的时间
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





            //不挣扎的时候，抓住一段时间弹回
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
