using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TextType : MonoBehaviour
{
    public float charsPerSecond = 0.2f;//打字时间间隔
    private string words;//保存需要显示的文字

    private bool isActive = false;
    private bool isPanelActive = false;
    private bool isPanelClose = false;
    private bool isPanelWork = false;
    private float timer;//计时器
    private float alpha = 1;

    public InputAction Skip;
    public float TurningSpeed = 1.0f;

    public Text myText;
    private int currentPos = 0;//当前打字位置

    private int PressCount = 0;
    public List<string> WordsList = new List<string>();

    public static TextType instance;
    public bool ShowFinalPicture = false;
    private void Awake()
    {
        instance = this;
        WordsList.Add("你是水的孩子，你是生灵的孩子，你是文明的孩子\n在这片由漩涡连接两界的泪水之海，\n你的使命就藏在无垠的海洋和无尽的沙漠之中");
        WordsList.Add("曾经的家被战争洗劫，如今空无一人，她或许已经流亡，无处可寻……\n你还有“时间”，既然过去已不可寻，那为什么不去未来找她呢？");
        WordsList.Add("这一份迟到了几十年的思念终于圆满，愿一切的遗憾，在今后的岁月中都能和解。");
        Skip.performed += 
         callback =>
        {
            SkipContent();
        };
    }
    private void OnEnable()
    {
        Skip.Enable();
    }
    private void OnDisable()
    {
        Skip.Disable();
    }
    // Use this for initialization
    void Start()
    {
        timer = 0;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);
        words = "";
        myText.text = "";//获取Text的文本信息，保存到words中，然后动态更新文本显示内容，实现打字机的效果
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PanelAlphaChange();
        OnStartWriter();
        PanelClose();
    }

    public void StartEffect()
    {
        isActive = true;
    }
    /// <summary>
    /// 执行打字任务
    /// </summary>
    void OnStartWriter()
    {

        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {//判断计时器时间是否到达
                timer = 0;
                currentPos++;
                myText.text = WordsList[0].Substring(0, currentPos);//刷新文本显示内容

                if (currentPos >= WordsList[0].Length)
                {
                    OnFinish();
                }
            }

        }
    }
    /// <summary>
    /// 结束打字，初始化数据
    /// </summary>
    void OnFinish()
    {
        isActive = false;
        timer = 0;
        currentPos = 0;
        myText.text = WordsList[0];
        StartCoroutine("TextStay");
    }
    public void ShowText(int number)
    {
        words = WordsList[number];
        isPanelActive = true;
    }
    void PanelAlphaChange()
    {
        if (isPanelActive)
        {
            alpha += TurningSpeed * Time.deltaTime;
            gameObject.GetComponent<Image>().color = new Color(0,0,0, alpha - 1);
            if(alpha > 0.95f + 1)
            {
                gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                isPanelActive = false;
                isActive = true;
                isPanelWork = true;
                myText.GetComponent<Text>().color = new Color(255, 255, 255, 1);
                alpha = 1;
            }
        }
    }
    void PanelClose()
    {
        if(isPanelClose)
        {
            alpha -= TurningSpeed * Time.deltaTime;
            gameObject.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            myText.GetComponent<Text>().color = new Color(255, 255, 255, alpha);
            if (alpha < 0.1f)
            {
                gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                myText.GetComponent<Text>().color = new Color(255, 255, 255, 0);
                myText.GetComponent<Text>().text = "";
                isPanelClose = false;
                if(GameManager.instance.IsWin)
                {
                    ShowFinalPicture = true;
                }
                alpha = 1;
            }
        }
    }
    private IEnumerator TextStay()
    {
        yield return new WaitForSeconds(2f);
        if (gameObject.GetComponent<Image>().color.a > 0.1f)
        {
            isPanelClose = true;
            isPanelWork = false;
        }
    }
    void SkipContent()
    {
        if (isPanelWork)
        {
            PressCount += 1;
            if (isActive)
            {
                if (PressCount == 1)
                {
                    OnFinish();
                }

            }
            if (PressCount == 2)
            {
                isPanelClose = true;
                isPanelWork = false;
                PressCount = 0;
            }
        }
    }
}
