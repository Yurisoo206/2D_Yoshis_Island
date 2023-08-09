using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public Vector3 followPos;
    public int followDelay;
    public Transform target;
    public Queue<Vector3> targetPos;

    private void Awake()
    {
        targetPos = new Queue<Vector3>();
    }

    private void Update()
    {
        Watch();
        Follow();
    }

    void Watch()
    {
        //Input Pos

        targetPos.Enqueue(target.position);

        // Output Pos
        if (targetPos.Count > followDelay)
        {
            followPos = targetPos.Dequeue();
        }
        
    }

    void Follow()
    {
        transform.position = followPos;
    }
}
