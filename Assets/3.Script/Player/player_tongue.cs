using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_tongue : MonoBehaviour
{

    void Update()
    {
        Eat();
        
    }

    private void Eat()
    {
        if (Input.GetMouseButton(0))
        {

            GetComponent<EdgeCollider2D>().isTrigger = false;

        }
        if (Input.GetMouseButtonUp(0))//�ٽ� �� edge false ó��
        {
            GetComponent<EdgeCollider2D>().isTrigger = true;
            
        }
    }

}
