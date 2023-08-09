using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    public GameObject target; 
    public float moveSpeed;
    private Vector3 targetPos;

    //------------------------
    //카메라 범위 제한
    public float limitX = 10;
    public float limitY = 10;
    internal static object main;

    private void Update()
    {
        if (target.gameObject != null)
        {
            targetPos.Set(target.transform.position.x + 1, target.transform.position.y + 0.5f, -10);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }
}
