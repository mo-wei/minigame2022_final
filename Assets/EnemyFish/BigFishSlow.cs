using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFishSlow : MonoBehaviour
{
    private FSM manager;
    private PlayerControl player;
    public bool isCanAttack = true;

    public float DashDistance;
    public float StopDistance;
    public bool IsDashing = false;

    public GameObject camp;
    public GameObject child;

    bool IsPlayerHide = false;

    public Vector2 DashVelocity;

    public Vector2 Direction;
    private void Start()
    {
        manager = child.GetComponent<FSM>();
        player = FindObjectOfType<PlayerControl>();
    }

    private void Update()
    {
        Debug.Log(manager.states[StateType.Chase]);
        if (manager.currentState == manager.states[StateType.Chase])
        {
            float distance = (player.transform.position - transform.position).magnitude;
            if (!player.GetComponent<PlayerControl>().IsHide)
            {
                Direction = (player.transform.position - transform.position).normalized;
            }
            if (distance > DashDistance)
            {
                if (manager.parameter.AI.canMove)
                {
                    manager.parameter.AI.maxSpeed = 8;
                    IsDashing = true;
                }
            }
            else if (!IsDashing && distance < DashDistance)
            {
                manager.parameter.AI.maxSpeed = 5;
            }
            else if (!IsPlayerHide && IsDashing && distance < StopDistance)
            {
                manager.parameter.AI.maxSpeed = 5;
                IsDashing = false;
                manager.parameter.AI.canMove = true;
            }
            if (player.GetComponent<PlayerControl>().IsHide)
            {
                IsPlayerHide = true;
                if (IsDashing)
                {
                    manager.parameter.AI.canMove = false;
                    gameObject.GetComponent<Rigidbody2D>().velocity = Direction * 10f;
                    print(gameObject.GetComponent<Rigidbody2D>().velocity);
                    StartCoroutine("CountDown");

                }
                else
                {
                    manager.parameter.currentVigilValue = 0;
                }
            }
            if (!player.GetComponent<PlayerControl>().IsHide && IsPlayerHide)
            {
                IsPlayerHide = false;
                manager.parameter.AI.canMove = true;
                if (IsDashing && camp.GetComponent<BigFishDetect>().player != null)
                {
                    manager.parameter.currentVigilValue = 5;
                }
            }
        }
    }
    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(2f);
        IsDashing = false;
        manager.parameter.AI.canMove = true;
        manager.parameter.currentVigilValue = 0;
    }
}
