using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public float Yoffset;
    public Camera mainCamera;
    public GameObject blackPanel;
    public GameObject HidePlatform;
    public GameObject Grass;

    public Vector2 LockPosition;

    public static GameManager instance;

    public bool GTOS = false;
    public bool STOG = false;

    public bool IsBlack = false;

    public float BlackTime;

    public GameObject GSControl;

    public bool IsSeedGet = false;
    public bool IsPowerGet = false;
    public bool IsSeeGet = false;

    public bool IsWin = false;
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        TextType.instance.ShowText(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Blacking();
        CameraFollow();
    }
    void CameraFollow()
    {
        Vector3 Pos = Player.transform.position - mainCamera.transform.position + new Vector3(0, Yoffset, 0);
        Pos.z = 0;
        if (LockPosition.x > 0 && Pos.x > 0)
            Pos.x = 0;
        else if(LockPosition.x < 0 && Pos.x < 0)
            Pos.x = 0;
        if (LockPosition.y > 0 && Pos.y > 0)
            Pos.y = 0;
        else if (LockPosition.y < 0 && Pos.y < 0)
            Pos.y = 0;
        mainCamera.transform.position += Pos / 20;
    }
    public void CameraLock(Vector2 direction)
    {
        LockPosition += direction;
    }
    public void CameraUnlock(Vector2 direction)
    {
        LockPosition -= direction;
    }
    public void ScreenBlack(float time)
    {
        IsBlack = true;
        blackPanel.SetActive(true);
        BlackTime = time;
        StartCoroutine("CountDown1");        
    }
    public IEnumerator CountDown1()
    {
        yield return new WaitForSeconds(BlackTime);
        IsBlack = false;
    }
    void Blacking()
    {
        float Alpha = blackPanel.GetComponent<Image>().color.a;
        Color newColor = blackPanel.GetComponent<Image>().color;
        if (IsBlack)
        {
            if(Alpha < 0.9f)
            {
                newColor.a += 2f * Time.deltaTime;
            }
            else
            {
                newColor.a = 1f;                
                if (GTOS)
                {
                    GSControl.SetActive(true);
                    Color newColor1 = GSControl.transform.Find("GrilandSprite").GetComponent<Image>().color;
                    newColor1.a = 1f;
                    GSControl.transform.Find("GrilandSprite").GetComponent<Image>().color = newColor1;
                    AnimationPlayer.instance.GrilToSpritePlay();
                    GTOS = false;
                }
                else if (STOG)
                {
                    GSControl.SetActive(true);
                    Color newColor1 = GSControl.transform.Find("GrilandSprite").GetComponent<Image>().color;
                    newColor1.a = 1f;
                    GSControl.transform.Find("GrilandSprite").GetComponent<Image>().color = newColor1;
                    AnimationPlayer.instance.SpriteToGrilPlay();
                    STOG = false;
                }
            }
            blackPanel.GetComponent<Image>().color = newColor;
        }
        else if(!IsBlack && Alpha > 0f)
        {
            if (Alpha > 0.1f)
            {
                newColor.a -= 2f * Time.deltaTime;
            }
            else
            {
                newColor.a = 0f;
                blackPanel.SetActive(false);
                GSControl.SetActive(false);
            }
            if(GSControl.activeInHierarchy)
                GSControl.transform.Find("GrilandSprite").GetComponent<Image>().color = new Color(GSControl.transform.Find("GrilandSprite").GetComponent<Image>().color.r, GSControl.transform.Find("GrilandSprite").GetComponent<Image>().color.g, GSControl.transform.Find("GrilandSprite").GetComponent<Image>().color.b, newColor.a);
            blackPanel.GetComponent<Image>().color = newColor;
        }
    }
    public void SeePlatforms()
    {
        HidePlatform.SetActive(true);
    }
    public void ClearGrass()
    {
        Grass.SetActive(false);
    }
}
