using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public int Mode = 0; //0´ý»ú£»1Æð·É£»2×·»÷£»3·µ»Ø
    public GameObject AttackTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    void ModeChange()
    {
        if(Mode == 0)
        {
            if(AttackTarget != null)
            {
                Mode = 1;
            }
        }
        else if(Mode == 1)
        {
            if(AttackTarget == null && BackPathCheck())
            {
                Mode = 3;
            }
            else if(AttackTarget != null && AttackPathCheck())
            {
                Mode = 2;
            }
        }
    }
    bool BackPathCheck()
    {
        return false;
    }
    bool AttackPathCheck()
    {
        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PlayerControl>().Dead();
        }
    }
}
