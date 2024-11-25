using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OtterHealth : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Otter has been defeated!");
        // Handle checkpoints, TBD
    }
}

