using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishes : MonoBehaviour
{
    private Collider2D myCollider;
    public float time;
    private float currentTime;
    private void Start()
    {
        currentTime = 0;
        myCollider = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //��֪�����Ҫȥ�����ó�̹���
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<PlayerControl>().isDashing)
            {
                myCollider.enabled = false;
                currentTime = time;
            }

        }
    }
    private void Update()
    {
        if(currentTime <= 0)
        {
            myCollider.enabled = true;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
}
