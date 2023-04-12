using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeSensor : MonoBehaviour
{
    public Vector2 LockPosition;
    private void OnBecameVisible()
    {
        GameManager.instance.CameraLock(LockPosition);
    }
    private void OnBecameInvisible()
    {
        GameManager.instance.CameraUnlock(LockPosition);
    }
}
