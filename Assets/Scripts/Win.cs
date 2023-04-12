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
                TextType.instance.WordsList[0] = "��������٣���ţ���ͷ�ϵ�ϸ����\n��������ƣ���չ�ţ��񼡷����Ѫ�ܣ�\n������Ĺǽڣ������ţ�ָ��ε��\n��������������Ҳ���Ӳ�ġ�ĸ�ס������������ǵĻ����е���\nFreya�����ǵİ�����"
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
