using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkEgg : MonoBehaviour
{
    public GameObject egg;
    public PlayerController player;
    private int speed = 5;


    void Update() 
    {
        if (Input.GetMouseButtonUp(1))
        {
            Instantiate(egg, transform.position, transform.rotation);
        }
        
        egg.transform.Translate(Vector3.up * this.speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 7);
    }

}
