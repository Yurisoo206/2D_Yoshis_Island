using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;//�ٸ� Ŭ�������� ���� ���� public �ٿ���
    [SerializeField] private Vector3 moveDirection = Vector3.zero;//����
    private Rigidbody2D playerR;

    private void Awake()
    {
        //playerR = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        //playerR.MovePosition(transform.position + moveDirection.normalized * moveSpeed * Time.deltaTime); //�� ���� �� �� �����Ÿ�(?) �ذ� �ڵ� �ٵ� �߷�(?)�ذ��
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
