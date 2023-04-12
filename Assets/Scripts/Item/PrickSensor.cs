using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrickSensor : MonoBehaviour
{
    bool IsActive = false;
    public float Yoffset = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IsActive)
        {
            if(Yoffset < 0.05F)
            {
                transform.parent.transform.position += new Vector3(0, Yoffset, 0);
                Yoffset = 0;
                IsActive = false;
                transform.parent.GetComponent<Prick>().IsActive = true;
            }
            else
            {
                transform.parent.transform.position += new Vector3(0, 4f, 0) * Time.deltaTime;
                Yoffset -= 4f * Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !transform.parent.GetComponent<Prick>().IsActive)
        {
            IsActive = true;
        }
    }
}
