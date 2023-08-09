using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario_Move : MonoBehaviour
{
    public PlayerController player;
    Rigidbody2D enemyR;
    public int nextMove = -1;//�ൿ��ǥ�� ������ ����
    public bool isMario = false;
    [SerializeField] private GameObject babyMario;

    private void Awake()
    {
        enemyR = GetComponent<Rigidbody2D>();
        ChangeMove();
        Invoke("ChangeMove", 5f);
        
    }

    private void Start()
    {
        player = GameObject.Find("Yoshis").GetComponent<PlayerController>();
        //�÷��̾� ��ġ���� ����
        
    }

    void FixedUpdate()
    {    

        enemyR.velocity = new Vector2(nextMove * 0.3f, 1 * 0.3f); //�ܼ� ���ʹ��� �̵� 
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
        Invoke("ChangeMove", 5f);
    }




}
