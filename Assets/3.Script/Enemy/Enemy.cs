using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyR;
    public PlayerController player;
    private Animator ani;
    public bool isEating = false;
    public bool isEat = false;
    public bool isDie= false;
    public bool isCatch= false;//�÷��̾�� ���� 
    public bool isCatching= false;//�÷��̾�� ����
    public float moveSpeed = 0.01f;
    public int nextMove;
    public Vector3 pos;
    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        isEat = player.isEat;
        isEating = player.isEating;
        pos = player.transform.position;
        Die();
    }

    public void Die()
    {
        if (isCatch == true)
        {
            ani.SetBool("Catch", isCatch);
            Debug.Log("����");
            //transform.position = new Vector3(pos.x+0.2f,pos.y,0.000000001f);
            //enemyR.velocity = new Vector2(nextMove, enemyR.velocity.y);

            if (Input.GetKey(KeyCode.S))
            {
                player.egg++;
                Destroy(gameObject);
            }
            //Destroy(gameObject);
        }       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetMouseButton(0))//���� �Ա�
        {
            Debug.Log("�Ծ�");
            GetComponent<CircleCollider2D>().isTrigger = true;
            isCatch = true;
        }
    }

}