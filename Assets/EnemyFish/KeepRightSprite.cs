using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRightSprite : MonoBehaviour
{
    private Transform parent;
    private Vector3 lastFramePos;
    Vector3 faceDirection;
    Vector3 PlayerToFish;
    public GameObject Player;
    public GameObject Fish;

    private void Start()
    {
        parent = this.transform.parent.parent;
    }

    private void Update()
    {
        faceDirection = parent.position - lastFramePos;
        PlayerToFish = Player.transform.position - parent.position;
        //print(faceDirection);
        lastFramePos = parent.position;
        faceDirection.z = 0;
        PlayerToFish.z = 0;
        if(Fish.GetComponent<BigFishSlow>() && !Fish.GetComponent<BigFishSlow>().IsDashing)
            transform.right += faceDirection.normalized / 10 + PlayerToFish.normalized / 20;
        else
            transform.right += faceDirection.normalized / 10;
        Debug.Log(transform.right);

    }
}
