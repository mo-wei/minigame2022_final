using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public List<GameObject> item = new List<GameObject>(); //所有物体

    public float force; //力的大小

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

    //爆炸
    public void Explosion()
    {
        //获取目场景中要爆炸的所有物体的中心点
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

        //模拟力
        foreach (GameObject temp in item)
        {
            //物体与爆炸中心的距离(越近的受到的爆炸力越大)
            float dis = Mathf.Abs(Vector2.Distance(temp.transform.position, midPos));
            Vector2 v = midPos - (Vector2)temp.transform.position;
            v = v + new Vector2(-5, 0);
            Vector2 dir = v.normalized;
            temp.GetComponent<Rigidbody2D>().gravityScale = 1;
            temp.GetComponent<Rigidbody2D>().velocity = -dir * (force - dis);
        }
    }
}

