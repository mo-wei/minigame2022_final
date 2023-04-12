using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFishDetect : MonoBehaviour
{
    public GameObject player = null;
    private FSM manager;
    public GameObject fsm;
    // Start is called before the first frame update
    void Start()
    {
        manager = fsm.GetComponent<FSM>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            player = collision.gameObject;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.tag == "Player")
            { 
                player = collision.gameObject;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            player = null;
        }
    }
}
