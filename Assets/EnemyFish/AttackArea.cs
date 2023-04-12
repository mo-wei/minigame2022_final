using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private FSM manager;
    private void Start()
    {
        manager = transform.parent.GetComponent<FSM>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            manager.parameter.target = collision.transform;
            manager.TranslateState(StateType.Attack);
        }
    }
}
