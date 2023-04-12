using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BagIsOpen: MonoBehaviour
{
    public GameObject myBag;
    public InputAction BagInput;
    private void Awake()
    {
        BagInput.performed += callback =>
        {
            AudioManager.instance.BagAudio();
            myBag.SetActive(!myBag.activeSelf);
        };
    }
    private void OnEnable()
    {
        BagInput.Enable();
    }
    private void OnDisable()
    {
        BagInput.Disable();
    }
   
}
