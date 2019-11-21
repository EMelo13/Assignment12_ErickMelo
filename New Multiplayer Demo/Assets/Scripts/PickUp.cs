using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PickUp : NetworkBehaviour
{
    float speed = 50;
 
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
            PlayerHealth playerHealth = new PlayerHealth(+20);
           
    }
}
