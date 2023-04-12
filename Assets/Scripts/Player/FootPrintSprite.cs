using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintSprite : MonoBehaviour
{
    private GameObject player;
    private Transform playertf, thistf;
    private SpriteRenderer playerSprite, thisSprite;
    private float dashStartTime;//��ʼ��ʾ��ʱ��
    private float existTime;//ά��ʱ��
    private Color color;
    private float alpha;//��ǰ͸����
    private float alphaSet = 0.8f;//���͸����
    private float alphaMuti = 0.8f;//͸�����½�����

    private bool IsFaded = false;

    //ʹ��ʱִ�У�����д��update��fixedupdate��
    void OnEnable()
    {
        player = GameObject.FindWithTag("Player");
        playertf = player.GetComponent<Transform>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        thistf = this.GetComponent<Transform>();
        thisSprite = this.GetComponent<SpriteRenderer>();
        alpha = alphaSet;
        dashStartTime = Time.time;
        thistf.position = playertf.position - new Vector3(0, 0.5f, 0);
        thistf.rotation = playertf.rotation;
        existTime = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        thistf = this.GetComponent<Transform>();
        thisSprite = this.GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        playertf = player.GetComponent<Transform>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        alphaSet = 1f;
        color = new Color(0.5f, 1, 0.5f, 1);
        existTime = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsFaded)
        {
            alpha = thisSprite.GetComponent<SpriteRenderer>().material.GetFloat("_Alpha"); 
            if(alpha > 0.1f)
                thisSprite.GetComponent<SpriteRenderer>().material.SetFloat("_Alpha", alpha - 1f * Time.deltaTime);
            else
                thisSprite.GetComponent<SpriteRenderer>().material.SetFloat("_Alpha", 0);
        }
        if (Time.time - dashStartTime > existTime)
        {
            //���ض����
            DashPoolControl.instance.BackToPool(this.gameObject);
        }
    }
    public IEnumerator startCountDown()
    {
        yield return new WaitForSeconds(0.4f);
        IsFaded = true;
    }
}
