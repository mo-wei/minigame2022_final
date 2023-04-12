using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandyPlatform : MonoBehaviour
{
    public float VisiableTime;
    public float HideTime;
    public List<GameObject> Pricks = new List<GameObject>();
    public GameObject Forward;

    float visiableTime;
    float hideTime;
    bool IsHide = true;

    bool IsHiding = false;
    bool IsVisiable = false;
    // Start is called before the first frame update
    void Start()
    {
        hideTime = Time.time;
        visiableTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IsHide)
        {
            if((Time.time - hideTime) > HideTime)
            {
                IsHide = false;
                visiableTime = Time.time;
                IsHiding = true;
            }
        }
        else
        {
            if ((Time.time - visiableTime) > VisiableTime)
            {
                IsHide = true;
                hideTime = Time.time;
                IsVisiable = true;
            }
        }
        if (IsHiding)
        {
            float Alpha = gameObject.GetComponent<SpriteRenderer>().material.GetFloat("_Alpha");
            if (Alpha > 0.1f)
            {
                gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_Alpha",Alpha - 3f * Time.deltaTime);
                for(int i = 0; i < Pricks.Count; i++)
                {
                    Pricks[i].GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 3f * Time.deltaTime);
                }
                Forward.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 3f * Time.deltaTime);
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_Alpha", 0);
                for (int i = 0; i < Pricks.Count; i++)
                {
                    Pricks[i].GetComponent<SpriteRenderer>().color = new Color(Pricks[i].GetComponent<SpriteRenderer>().color.r, Pricks[i].GetComponent<SpriteRenderer>().color.g, Pricks[i].GetComponent<SpriteRenderer>().color.b,0);
                }
                Forward.GetComponent<SpriteRenderer>().color = new Color(Forward.GetComponent<SpriteRenderer>().color.r, Forward.GetComponent<SpriteRenderer>().color.g, Forward.GetComponent<SpriteRenderer>().color.b, 0);
                IsHiding = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Forward.transform.gameObject.SetActive(false);
                for (int i = 0; i < Pricks.Count; i++)
                {
                    Pricks[i].transform.parent.gameObject.SetActive(false);
                }
            }
        }
        if (IsVisiable)
        {
            float Alpha = gameObject.GetComponent<SpriteRenderer>().material.GetFloat("_Alpha");
            for (int i = 0; i < Pricks.Count; i++)
            {
                Pricks[i].transform.parent.gameObject.SetActive(true);
            }
            Forward.transform.gameObject.SetActive(true);
            if (Alpha< 0.9f)
            {
                gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_Alpha", Alpha + 3f * Time.deltaTime);
                for (int i = 0; i < Pricks.Count; i++)
                {
                    Pricks[i].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 3f * Time.deltaTime);
                }
                Forward.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 3f * Time.deltaTime);
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_Alpha", 1);
                for (int i = 0; i < Pricks.Count; i++)
                {
                    Pricks[i].GetComponent<SpriteRenderer>().color = new Color(Pricks[i].GetComponent<SpriteRenderer>().color.r, Pricks[i].GetComponent<SpriteRenderer>().color.g, Pricks[i].GetComponent<SpriteRenderer>().color.b, 1);
                }
                Forward.GetComponent<SpriteRenderer>().color = new Color(Forward.GetComponent<SpriteRenderer>().color.r, Forward.GetComponent<SpriteRenderer>().color.g, Forward.GetComponent<SpriteRenderer>().color.b, 1);
                IsVisiable = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                
            }

        }
    }
}
