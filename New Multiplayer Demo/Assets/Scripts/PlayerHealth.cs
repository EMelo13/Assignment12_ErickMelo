using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerHealth: MonoBehaviour {

    public int health;
    public PlayerHealth(int health)
    {
        this.health = health;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
    }
}
