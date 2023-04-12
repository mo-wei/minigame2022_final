using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintPoolControl : MonoBehaviour
{
    public static FootPrintPoolControl instance;
    void Awake()
    {
        instance = this;
    }

    private Queue<GameObject> objectPool;
    //������Ӧ������Ԥ����
    private GameObject[] footPrints;
    public GameObject footPrintPrefab;
    public int poolCount = 10;
    void Init()
    {
        for (int i = 0; i < poolCount; i++)
        {
            footPrints[i] = Instantiate(footPrintPrefab);
            footPrints[i].GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
            BackToPool(footPrints[i]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        footPrints = new GameObject[poolCount];
        objectPool = new Queue<GameObject>();
        Init();
    }
    //����Ҫupdate��ֻ��Ҫ��ʼ�����ⲿ����
    //��������
    private GameObject output;
    public GameObject ExitPool()
    {
        if (objectPool.Count == 0)
        {
            Init();
        }
        output = objectPool.Dequeue();
        output.SetActive(true);
        return output;
    }

    //���������
    public void BackToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        objectPool.Enqueue(gameObject);
    }
}
