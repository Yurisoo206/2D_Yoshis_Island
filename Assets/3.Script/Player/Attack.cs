using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Attack : MonoBehaviour
{
    public AtkEgg_shoot atkegg;
    [SerializeField] public float speed;

    private void Awake()
    {
        atkegg = transform.GetComponent<AtkEgg_shoot>();
    }
    void Start()
    {
        speed = 50f;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.Q) && Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime * -1));
        }

        if (Input.GetMouseButtonUp(1))
        {
            atkegg.startFire();
        }
        if (Input.GetMouseButtonUp(1))
        {

            atkegg.StopFire();
        }

        
    }
}
