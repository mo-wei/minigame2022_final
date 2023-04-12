using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class GetCollet : MonoBehaviour
{
    public List<Image> image;
    private Image collimage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collection"))
        {
            for (int i = 0; i < 5; i++)
            {
                image[i].sprite=collision.gameObject.GetComponent<Image>().sprite;
                
            }
            
        }
    }
}
