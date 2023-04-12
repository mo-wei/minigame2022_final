using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPoolControl : MonoBehaviour
{
    public static DashPoolControl instance;
    void Awake()
    {
        instance = this;
    }

    private Queue<GameObject> objectPool;
    //������Ӧ������Ԥ����
    private GameObject[] shadows;
    public GameObject shadowPrefab;
    public int poolCount = 10;
    void Init()
    {
        for (int i = 0; i < poolCount; i++)
        {
            shadows[i] = Instantiate(shadowPrefab);
            shadows[i].GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
            BackToPool(shadows[i]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        shadows = new GameObject[poolCount];
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
