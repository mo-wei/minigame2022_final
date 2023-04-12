using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    public GameObject Dialog;
    public Text text;

    public List<string> texts;
    public int PageCount = 0;
    public bool IsUsed = false;
    public bool IsUsing = false;

    public InputAction Skip;

    GameObject player;
    private void Awake()
    {
        Skip.performed += callback =>
        {
            if (IsUsing)
            {
                if (PageCount == texts.Count)
                {
                    Dialog.SetActive(false);
                    IsUsed = true;
                    IsUsing = false;
                    StartCoroutine("CanMove");
                }
                else
                {
                    text.text = texts[PageCount];
                    PageCount += 1;
                }
            }
        };
    }
    private void OnEnable()
    {
        Skip.Enable();
    }
    private void OnDisable()
    {
        Skip.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !IsUsed)
        {
            Debug.Log(111);
            collision.gameObject.GetComponent<PlayerControl>().IsStop = true;
            player = collision.gameObject;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Dialog.SetActive(true);
            IsUsing = true;
            text.text = texts[0];
            PageCount += 1;
        }
    }
    IEnumerator CanMove()
    {
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<PlayerControl>().IsStop = false;
    }
}
