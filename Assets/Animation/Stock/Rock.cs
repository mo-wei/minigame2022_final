using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public List<GameObject> item = new List<GameObject>(); //��������

    public float force; //���Ĵ�С

    public PolygonCollider2D cl;
    private void Start()
    {
        cl = this.transform.GetComponent<PolygonCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BigFish") && collision.gameObject.GetComponentInChildren<BigFishSlow>().IsDashing)
        {
            cl.enabled = false;
            Explosion();
            AudioManager.instance.RockAudio();
        }
    }

    //��ը
    public void Explosion()
    {
        //��ȡĿ������Ҫ��ը��������������ĵ�
        float minX = item[0].transform.position.x;
        float maxX = item[0].transform.position.x;
        float minY = item[0].transform.position.y;
        float maxY = item[0].transform.position.y;
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].transform.position.x < minX)
            {
                minX = item[i].transform.position.x;
            }
        }
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].transform.position.x > maxX)
            {
                maxX = item[i].transform.position.x;
            }
        }
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].transform.position.y < minY)
            {
                minY = item[i].transform.position.y;
            }
        }
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].transform.position.y > maxY)
            {
                maxY = item[i].transform.position.y;
            }
        }
        Vector2 midPos = new Vector2((maxX + minX) / 2, (maxY + minY) / 2);

        //ģ����
        foreach (GameObject temp in item)
        {
            //�����뱬ը���ĵľ���(Խ�����ܵ��ı�ը��Խ��)
            float dis = Mathf.Abs(Vector2.Distance(temp.transform.position, midPos));
            Vector2 v = midPos - (Vector2)temp.transform.position;
            v = v + new Vector2(-5, 0);
            Vector2 dir = v.normalized;
            temp.GetComponent<Rigidbody2D>().gravityScale = 1;
            temp.GetComponent<Rigidbody2D>().velocity = -dir * (force - dis);
        }
    }
}

