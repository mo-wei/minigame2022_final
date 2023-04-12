using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存档管理器
/// </summary>
public class SaveManager : MonoBehaviour
{
    public SavePoint[] savePoints;
    public SavePoint currentSavePoint;
    public List<Transform> SavePositions;
    public Transform currentPosition;

    private void Start()
    {
        //初始化
        for(int i = 0; i < savePoints.Length; i++)
        {
            savePoints[i].saveId = i;
        }
    }


    public void ChangeSavePoint(int destinationID)
    {
        currentSavePoint = savePoints[destinationID];
        currentPosition = SavePositions[destinationID];
    }
}
