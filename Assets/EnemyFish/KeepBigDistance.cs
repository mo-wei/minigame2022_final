using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepBigDistance : MonoBehaviour
{
    public float StopDistance;
    public float FollowDistance;
    public Transform fish;
    private void Update()
    {
        if(Vector3.Distance(fish.position, this.transform.position) > FollowDistance)
        {
            if (!fish.gameObject.GetComponent<BigFishSlow>().IsDashing)
            {
                print(1);
                fish.GetComponentInChildren<FSM>().parameter.AI.canMove = true;
            }
        }
        else if(Vector3.Distance(fish.position, this.transform.position) < StopDistance)
        {
            if (!fish.gameObject.GetComponent<BigFishSlow>().IsDashing)
            {
                print(2);
                fish.GetComponentInChildren<FSM>().parameter.AI.canMove = false;
                fish.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }
}
