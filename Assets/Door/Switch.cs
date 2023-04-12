using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Switch : MonoBehaviour
{
    public Transform door;
    public InputAction openDoor;

    private void OnEnable()
    {
        openDoor.Enable();
    }
    private void OnDisable()
    {
        openDoor.Disable();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(openDoor.IsPressed() && door.gameObject.activeSelf)
            {
                AudioManager.instance.SwitchAudio();
                GetComponent<Animator>().Play("Switch");
                door.gameObject.SetActive(false);
            }
        }
    }
    
}
