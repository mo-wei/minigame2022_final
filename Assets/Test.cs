using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public AnimationClip clip;
    private Animator myAnimation;
    private void Start()
    {
       myAnimation = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myAnimation.Play("BigFish");
            print(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            myAnimation.Play("LittleFish");
            print(2);
        }
    }
}
