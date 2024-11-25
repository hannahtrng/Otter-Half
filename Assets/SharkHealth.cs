using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkHealth : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Shark took damage! Current health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Shark has been defeated!");
        // Handle shark death, e.g., disable it or play an animation
        //gameObject.SetActive(false);
    }
}

