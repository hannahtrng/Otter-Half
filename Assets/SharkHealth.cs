using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.UI; // Required for UI components

public class SharkHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public Slider healthBar; // Assign the Shark's health bar in the Inspector

    void Start()
    {
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Shark took damage! Current health: " + health);

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
        Debug.Log("Shark has been defeated!");
        // Handle shark death, e.g., disable it or play an animation
        //gameObject.SetActive(false);
    }
}
