using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public bool IsFish = false;
    public InputAction MoveInput;
    public InputAction JumpInput;
    public InputAction DashInput;
    public InputAction HideInput;

    public bool IsGround = false;

    public float MoveSpeed;
    public float JumpSpeed;
    public float DashSpeed;
    public int JumpTimes;
    public float DasheTimeSet;

    public int JumpTime;

    public Rigidbody2D m_rigidbody2D;

    public Camera mainCamera;

    float Yoffset = 0f;
    bool IsDead = false;

    public bool HideCD = true;
    public bool DashCD = true;
    public bool IsHide = true;
    public bool IsStop = false;
    float DashTime;
    public bool isDashing = false;
    bool IsHideTimeCounting = false;
    Vector2 DashDirection;
    public SaveManager saveManager;
    public Animator animator;
    int baseLayer;
    int girlLayer;
    int spriteLayer;
    public bool IsDashEnable = false;
    public bool IsDoubleJumpEnable = false;
    public static PlayerControl instance;

    bool IsDoubleJump = false;
    private void Awake()
    {
        instance = this;
        JumpInput.performed += Jump;
        JumpTime = JumpTimes;
        DashInput.performed += callback =>
        {
            if (DashCD && !isDashing && IsDashEnable)
            {
                isDashing = true;
                DashTime = DasheTimeSet;
                DashDirection = MoveInput.ReadValue<Vector2>();
            }
        };
        animator = GetComponent<Animator>();
        baseLayer = animator.GetLayerIndex("Base");
        girlLayer = animator.GetLayerIndex("GirlLayer");
        spriteLayer = animator.GetLayerIndex("SpriteLayer");
        animator.SetLayerWeight(baseLayer, 0f);
        animator.SetLayerWeight(girlLayer, 0f);
        animator.SetLayerWeight(spriteLayer, 1f);
    }
    private void OnEnable()
    {
        MoveInput.Enable();
        JumpInput.Enable();
        DashInput.Enable();
        HideInput.Enable();
    }
    private void OnDisable()
    {
        MoveInput.Disable();
        JumpInput.Disable();
        DashInput.Disable();
        HideInput.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove(MoveInput.ReadValue<Vector2>());
        Hide();
        Dash();
    }
    private void PlayerMove(Vector2 direction)
    {
        if(IsFish && !isDashing && !IsStop && !gameObject.GetComponent<Struggle>().isStruggle)
        {
            m_rigidbody2D.velocity = new Vector2(direction.x * MoveSpeed, direction.y * MoveSpeed);
            animator.SetFloat("Horizontal", direction.x);
        }   
        else if(!IsFish &&!IsStop)
        {
            m_rigidbody2D.velocity = new Vector2(direction.x * MoveSpeed, m_rigidbody2D.velocity.y);
            animator.SetFloat("Horizontal", direction.x);
            AudioManager.instance.WalkAudio();
        }    
    }
    private void Jump(InputAction.CallbackContext callbackContext)
    {
        if (!IsFish && !IsStop)
        {
            IsGround = false;
            if (JumpTime > 0)
            {
                AudioManager.instance.JumpAudio();
                if(IsDoubleJump && JumpTimes == 2 && JumpTime == 1)
                {
                    animator.SetBool("IsJumpTwo", true);
                    IsDoubleJump = false;
                }
                else
                {
                    animator.SetBool("IsJump", true);
                    if (JumpTime == 2)
                        IsDoubleJump = true;
                }
                m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, JumpSpeed);
                JumpTime -= 1;
            }
        }
    }
    private void Dash()
    {
        if(IsFish && isDashing && !IsStop && !gameObject.GetComponent<Struggle>().isStruggle && IsDashEnable)
        {
            AudioManager.instance.DashAudio();
            DashCD = false;
            if (DashTime <= 0)
            {
                isDashing = false;
                DashTime = 0;
                StartCoroutine("startCountDownDash");
                return;
            }
            m_rigidbody2D.velocity = DashDirection * DashSpeed;
            DashTime = DashTime - Time.deltaTime;
            //在对象池中提取对象
            DashPoolControl.instance.ExitPool();
        }
    }
    private void Hide()
    {
        float Alpha = gameObject.GetComponent<SpriteRenderer>().material.GetFloat("_Alpha");
        if (IsFish && MoveInput.ReadValue<Vector2>() == new Vector2(0, 0) && HideCD && HideInput.ReadValue<float>() == 1&& !gameObject.GetComponent<Struggle>().isStruggle)
        {
            IsHide = true;
            if (Alpha > 0f)
            {
                if (Alpha > 0.1f)
                {
                    gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_Alpha", Alpha - 4f * Time.deltaTime);
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_Alpha", 0f);
                    gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                    gameObject.layer = 3;
                    gameObject.transform.Find("IsGround").gameObject.layer = 3;
                    gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                }
            }
        }
        else if(IsFish && Alpha < 1f && (!HideCD || MoveInput.ReadValue<Vector2>() != new Vector2(0, 0) || HideInput.ReadValue<float>() == 0))
        {
            IsHide = false;
            HideCD = false;
            StartCoroutine("startCountDown");
            if (Alpha < 1f)
            {
                if (Alpha < 0.9f)
                {
                    gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_Alpha", Alpha + 4f * Time.deltaTime);
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_Alpha", 1f);
                    gameObject.GetComponent<CapsuleCollider2D>().enabled = true ;
                    gameObject.layer = 0;
                    gameObject.transform.Find("IsGround").gameObject.layer = 0;
                    gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }
        }
    }
    public void ChangeCondition()
    {
        IsFish = !IsFish;
        if(IsFish)
        {
            m_rigidbody2D.gravityScale = 0;
            animator.SetLayerWeight(baseLayer, 0f);
            animator.SetLayerWeight(girlLayer, 0f);
            animator.SetLayerWeight(spriteLayer, 1f);
            gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(1.04f, 0.0001f);
        }
        else
        {
            m_rigidbody2D.gravityScale = 1;
            animator.SetLayerWeight(baseLayer, 0f);
            animator.SetLayerWeight(girlLayer, 1f);
            animator.SetLayerWeight(spriteLayer, 0f);
            gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(0.57f, 1.2f);
        }
    }
    public IEnumerator startCountDown()
    {
        yield return new WaitForSeconds(1f);
        HideCD = true;
    }
    public IEnumerator startCountDownDash()
    {
        yield return new WaitForSeconds(1f);
        DashCD = true;
    }

    //更改死亡状态
    public void Dead()
    {
        AudioManager.instance.DeadAudio();
        StartCoroutine("DeadCount");
        GameManager.instance.ScreenBlack(0.5f);
        if(IsFish)
        {
            animator.Play("dead_sprite");
        }
        else
        {
            animator.Play("dead_girl");
        }
        IsStop = true;
    }
    IEnumerator DeadCount()
    {
        yield return new WaitForSeconds(0.5f);
        this.transform.position = saveManager.currentSavePoint.transform.position;
        if (IsFish)
        {
            animator.Play("swim_left");
        }
        else
        {
            animator.Play("run_right");
        }
        mainCamera.transform.position = saveManager.currentPosition.position + new Vector3(0,0,-10);
        IsStop = false;
    }
}
