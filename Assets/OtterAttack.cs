using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtterAttack : MonoBehaviour
{
    public int attackDamage = 10; // Damage dealt by the otter
    public float attackRange = 1.5f; // Range within which the shark can be attacked
    public KeyCode attackKey = KeyCode.Space; // Key to trigger the attack
    public LayerMask sharkLayer; // Layer to identify the shark

    void Update()
    {
        // Check if the attack key is pressed
        if (Input.GetKeyDown(attackKey))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Check if the shark is within range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, sharkLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // Apply damage to the shark
            SharkHealth sharkHealth = enemy.GetComponent<SharkHealth>();
            if (sharkHealth != null)
            {
                sharkHealth.TakeDamage(attackDamage);
                Debug.Log("Otter attacked the shark!");
            }
        }
    }

    // Visualize the attack range in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
