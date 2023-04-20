using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkEgg_shoot : MonoBehaviour
{
    [SerializeField] private GameObject egg;
    [SerializeField] private float Attack_Rate = 0.5f;

    public void TryAttack()
    {
        Instantiate(egg, transform.position, Quaternion.identity);
    }
    private IEnumerator TryAttack_co()
    {
        while (true)
        {
            Instantiate(egg, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Attack_Rate);
        }
    }


    public void startFire()
    {
        StartCoroutine("TryAttack_co");
    }
    public void StopFire()
    {
        StopCoroutine("TryAttack_co");
    }

}
