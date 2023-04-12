using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Transform> Positions;
    public float MoveSpeed;
    public float StayTime;

    bool IsStay = false;
    int Condition = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Moving();
    }
    void Moving()
    {
        if (!IsStay)
        {
            Vector3 targetPosition;
            targetPosition = Positions[Condition].position;
            Vector3 Direction = (targetPosition - transform.position).normalized;
            transform.position += Direction * MoveSpeed * Time.deltaTime;
            if (((Vector2)(targetPosition - transform.position)).magnitude < 0.1f)
            {
                transform.position = targetPosition;
                Condition += 1;
                IsStay = true;
                StartCoroutine("CountDown");
                if (Condition == Positions.Count)
                {
                    Condition = 0;
                }
            }
        }
    }
    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(StayTime);
        IsStay = false;
    }
}
