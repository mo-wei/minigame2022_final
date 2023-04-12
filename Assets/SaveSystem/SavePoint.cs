using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存档点
/// </summary>
public class SavePoint : MonoBehaviour
{
    //存档点编号
    public int saveId;
    private SaveManager manager;
    private void Start()
    {
        manager = this.transform.parent.GetComponent<SaveManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //调用人物重生点设置函数
            manager.ChangeSavePoint(saveId);
        }
    }
}
