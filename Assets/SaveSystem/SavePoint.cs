using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �浵��
/// </summary>
public class SavePoint : MonoBehaviour
{
    //�浵����
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
            //�����������������ú���
            manager.ChangeSavePoint(saveId);
        }
    }
}
