using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI; // Required for UI components

public class SharkHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public Slider healthBar; // Assign the Shark's health bar in the Inspector

    public void SetSharkFightVictoryTrue()
    {
        SettingsManager.Instance.hasWonFight = true;
    }

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
        if (SFXmanager.Instance != null && SFXmanager.Instance.FightSound != null)
        {
            SFXmanager.Instance.DeathSound.Play();
        }
        SetSharkFightVictoryTrue();
        // Stop all movements for both Shark and Otter
        StopAllMovements();

        // Return to the Cave scene
        SceneManager.LoadScene("Cave"); // Replace "Cave" with your scene's actual name
    }

    void StopAllMovements()
    {

        // Optionally stop the Shark's Rigidbody
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // Stop movement
            rb.angularVelocity = 0f;   // Stop rotation
        }

        // Find the Otter and stop its movements
        GameObject otter = GameObject.FindWithTag("Player"); // Ensure the Otter has the "Otter" tag
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

