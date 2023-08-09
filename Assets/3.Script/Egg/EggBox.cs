using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBox : MonoBehaviour
{
    [SerializeField] private GameObject eggBonus;
    public int count;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (count>=1 && collision.gameObject.CompareTag("Player"))
        {
            eggBonus.SetActive(true);
            count--;  
        }
        else
        {
            return;
        }
    }
}
