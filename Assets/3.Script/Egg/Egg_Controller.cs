using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_Controller : MonoBehaviour
{
    public PlayerController player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            player.egg++;
            Debug.Log("æ∆ΩŒ æÀ¿Ã¥Ÿ");
            

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 10);
        }
        
        

    }

}
