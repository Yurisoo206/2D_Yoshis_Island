using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_move : MonoBehaviour
{
    public Rigidbody2D eggR;
    public int nextMove = -1;//�ൿ��ǥ�� ������ ����
    public Transform target;
    public float moveSpeed = 5f;

    private void Awake()
    {
        eggR = GetComponent<Rigidbody2D>();
        ChangeMove();

        Invoke("ChangeMove", 5f);//Invoke();�־��� �ð��� ���� �� ������ �Լ��� ����
    }

    void FixedUpdate()
    {
        eggR.velocity = new Vector2(nextMove * 0.3f, eggR.velocity.y); //���� �̵�
                                                                     
    }

    //�ൿ��ǥ�� �ٲ��� ����
    void ChangeMove()
    {
        nextMove = Random.Range(-1, 1);

        if (nextMove == -1)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (nextMove == 0)
        {
            nextMove = 1;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        Invoke("ChangeMove", 7f);//����Լ� : ������ ȣ�� ������ ���� ����Լ� ����� �� ����


    }
    
}
