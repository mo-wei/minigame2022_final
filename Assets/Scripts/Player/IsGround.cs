using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Wall")
        {
            transform.parent.GetComponent<PlayerControl>().IsGround = true;
            transform.parent.GetComponent<PlayerControl>().animator.SetBool("IsJump", false);
            transform.parent.GetComponent<PlayerControl>().animator.SetBool("IsJumpTwo", false);
            if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
            {
                transform.parent.GetComponent<PlayerControl>().JumpTime = transform.parent.GetComponent<PlayerControl>().JumpTimes;              
            }
        }
    }
}
