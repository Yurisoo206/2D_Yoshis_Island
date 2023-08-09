using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    Rigidbody2D enemyR;
    public int nextMove = -1;
    public float moveSpeed = 5f;

    private void Awake()
    {
        enemyR = GetComponent<Rigidbody2D>();
        ChangeMove();
        
        Invoke("ChangeMove", 5f);
    }

    void FixedUpdate()
    {
        enemyR.velocity = new Vector2(nextMove*0.3f, enemyR.velocity.y); //방향 이동           
    }

    //행동지표를 바꿔줄 로직
    void ChangeMove()
    {
        nextMove = Random.Range(-1,1);

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
