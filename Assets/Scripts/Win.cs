using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public InputAction WinInput;
    public GameObject picture;

    bool IsAble = false;
    private void Awake()
    {
        WinInput.performed += callback =>
        {
            if(IsAble && GameManager.instance.IsSeedGet && GameManager.instance.IsSeeGet)
            {
                GameManager.instance.IsWin = true;
                GameManager.instance.ScreenBlack(20f);
                TextType.instance.WordsList[0] = "数不清的蕾，蓬勃着，像头上的细汗；\n数不清的纹，伸展着，像肌肤里的血管；\n数不清的骨节，挣扎着，指向蔚蓝\n我们是最柔软，但也最坚硬的“母亲”，生命在我们的怀抱中诞生\nFreya，我们的爱与善"
;
                TextType.instance.ShowText(0);
            }
        };
    }
    private void OnEnable()
    {
        WinInput.Enable();
    }
    private void OnDisable()
    {
        WinInput.Disable();
    }
    private void FixedUpdate()
    {
        if(TextType.instance.ShowFinalPicture)
        {
            picture.SetActive(true);
            Color newColor = picture.GetComponent<Image>().color;
            if(newColor.a < 0.9f)
            {
                newColor.a += 1f * Time.deltaTime;
                picture.GetComponent<Image>().color = newColor;
            }
            else
            {
                newColor.a = 1f;
                picture.GetComponent<Image>().color = newColor;
                StartCoroutine("CountDown");
            }
        }
    }
    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Start");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            IsAble = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            IsAble = false;
        }
    }
}
