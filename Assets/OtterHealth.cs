using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for UI components

public class OtterHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public Slider healthBar; // Assign the Otter's health bar in the Inspector

    void Start()
    {
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = health;
        }
    }

    void Die()
    {
        Debug.Log("Otter has been defeated!");
        // Handle checkpoints, TBD
    }
}


