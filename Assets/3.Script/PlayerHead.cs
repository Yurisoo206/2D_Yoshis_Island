using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    private Animator ani;
    [SerializeField] public bool isRun = false;
    public bool isJump = false;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        Jump();
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.A))
        {
            isRun = false;
            isRun = true;;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isRun = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            isRun = false;
            isRun = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isRun = false;
        }

        ani.SetBool("Run", isRun);
        
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isJump = true;
        }
        ani.SetBool("Jump", isJump);
    }

    private void OnCollisionEnter2D(Collision2D collision) // �浹��
    {
        //�浹�� ���� ��� ����
        if (collision.gameObject.tag == "Map")//�ʰ� ��ֹ�
        {
            isJump = false;
        }
        if (collision.gameObject.tag == "Enemy")// ��
        {
            isJump = false;
        }
    }

}
