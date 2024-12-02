using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
        if (SFXmanager.Instance != null && SFXmanager.Instance.DeathSound != null)
        {
            SFXmanager.Instance.DeathSound.Play();
        }
        // Stop all movements
        StopAllMovements();

        // Return to the title screen
        SceneManager.LoadScene("Game Over (Lose)"); // Replace "TitleScreen" with the actual name of your title scene
    }

    void StopAllMovements()
    {

        // Optionally stop Rigidbody movement
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // Stop movement
            rb.angularVelocity = 0f;   // Stop rotation
        }

        // Find the Otter and stop its movements

        GameObject otter = GameObject.FindWithTag("Otter"); // Ensure the Otter has the "Otter" tag
        if (otter != null)
        {
            foreach (MonoBehaviour script in otter.GetComponents<MonoBehaviour>())
            {
                script.enabled = false; // Disable all scripts on the Otter
            }

            Rigidbody2D otterRb = otter.GetComponent<Rigidbody2D>();
            if (otterRb != null)
            {
                otterRb.velocity = Vector2.zero; // Stop Otter movement
                otterRb.angularVelocity = 0f;   // Stop Otter rotation
            }
        }
    }
}

