using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    public Button m_Button;
    public GameObject myBag;

    void Start()
    {
        m_Button.onClick.AddListener(ButtonOnClickEvent);
    }
    public void ButtonOnClickEvent()
    {
        myBag.SetActive(!myBag.activeSelf);
    }
}
