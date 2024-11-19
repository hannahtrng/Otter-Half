using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public float chargeAttackDelay = 5f; // Time before a big attack
    private bool isChargingAttack = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Otter"))
        {
            if (!isChargingAttack)
            {
                // Regular attack
                OtterHealth otterHealth = collision.gameObject.GetComponent<OtterHealth>();
                if (otterHealth != null)
                {
                    otterHealth.TakeDamage(attackDamage);
                }
            }
        }
    }

    IEnumerator ChargeAttack(GameObject otter)
    {
        isChargingAttack = true;
        yield return new WaitForSeconds(chargeAttackDelay);

        // Perform the big attack
        OtterHealth otterHealth = otter.GetComponent<OtterHealth>();
        if (otterHealth != null)
        {
            otterHealth.TakeDamage(999); // Big attack deals high damage
        }

        isChargingAttack = false;
    }
}
