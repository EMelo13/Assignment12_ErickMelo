using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PickUp : NetworkBehaviour
{
    float speed = 50;
    PlayerHealth playerHealth;
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter(Collider player)
    {
            PlayerHealth playerHealth = new PlayerHealth(+20);
           
    }
}
