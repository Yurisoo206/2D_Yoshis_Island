using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enter : MonoBehaviour
{
    public GameObject player;


    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.S))
        {
            player.transform.position = new Vector3(30.5f, -2.5f, 0);
        }
 
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.W))
        {
            player.transform.position = new Vector3(23, 1.5f, 0);
        }

        
    }

}
