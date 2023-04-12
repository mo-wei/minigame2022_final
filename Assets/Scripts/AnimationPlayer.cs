using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animator animator;

    public static AnimationPlayer instance;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GrilToSpritePlay()
    {
        animator.Play("SpriteToGirl");
    }
    public void SpriteToGrilPlay()
    {
        animator.Play("GirlToSprite");
    }
}
