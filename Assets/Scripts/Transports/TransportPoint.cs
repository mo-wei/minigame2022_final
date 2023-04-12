using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportPoint : MonoBehaviour
{
    public List<Transform> AimPositions = new List<Transform>();
    public List<Transform> AimPoints = new List<Transform>();
    public List<Transform> CameraAimPositions = new List<Transform>();
    public bool IsSea;
    public GameObject panel;
    public Camera mainCamera;

    int ChooseNumber = 0;
    public bool IsOut = true;
    public GameObject player;
    public bool IsSeaTwo = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsOut)
        {
            if (IsSea)
            {
                if (collision.tag == "Player")
                {
                    if (!IsSeaTwo)
                    {
                        panel.SetActive(true);
                        player.GetComponent<PlayerControl>().IsStop = true;
                        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    }
                    else
                    {
                        StartCoroutine("startCountDown");
                        GameManager.instance.ScreenBlack(3F);
                        GameManager.instance.STOG = true;
                    }
                }
            }
            else
            {
                if (collision.tag == "Player")
                {
                    StartCoroutine("startCountDown");
                    GameManager.instance.ScreenBlack(3F);
                    GameManager.instance.GTOS = true;
                }
            }
        }
        else
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsOut = true;
        }
    }
    public IEnumerator startCountDown()
    {
        yield return new WaitForSeconds(1f);
        ChangePosition(ChooseNumber);
        ChooseNumber = 0;
        
    }
    void ChangePosition(int num)
    {
        if(IsSea)
        {
            BGM.instance.SandAudio();
        }
        else
        {
            BGM.instance.SeaAudio();
        }
        AudioManager.instance.SwitchSceneAudio();
        IsOut = true;
        AimPoints[num].gameObject.GetComponent<TransportPoint>().IsOut = false;
        player.transform.position = AimPositions[num].position;
        mainCamera.transform.position = CameraAimPositions[num].position;
        player.GetComponent<PlayerControl>().ChangeCondition();
    }
    public void OnLeft()
    {
        ChooseNumber = 0;
        StartCoroutine("startCountDown");
        GameManager.instance.ScreenBlack(3F);
        GameManager.instance.STOG = true;
        panel.SetActive(false);
        player.GetComponent<PlayerControl>().IsStop = false;
    }
    public void OnRight()
    {
        ChooseNumber = 1;
        StartCoroutine("startCountDown");
        GameManager.instance.ScreenBlack(3F);
        GameManager.instance.STOG = true;
        panel.SetActive(false);
        player.GetComponent<PlayerControl>().IsStop = false;
    }
}
