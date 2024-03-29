using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private Vector3 moveDirection = Vector3.zero;//����
    private Rigidbody2D playerR;

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;       
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
