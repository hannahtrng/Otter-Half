using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public int chargeAttackDamage = 999;
    public float chargeAttackDelay = 1f;
    public float chargeSpeed = 10f;
    public float knockbackDistance = 1f;
    private bool isChargingAttack = false;

    private int attackCount = 0;
    private int attacksBeforeCharge = 4;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isChargingAttack)
            {
                OtterHealth otterHealth = collision.gameObject.GetComponent<OtterHealth>();
                if (otterHealth != null)
                {
                    otterHealth.TakeDamage(attackDamage);
                    if (SFXmanager.Instance != null && SFXmanager.Instance.TakeDamageSound != null)
                    {
                        SFXmanager.Instance.TakeDamageSound.Play();
                    }
                    Debug.Log("Shark attacked the player!");
                }
                else
                {
                    Debug.Log("Player detected, but no OtterHealth component found.");
                }

                attackCount++;
                if (attackCount >= attacksBeforeCharge)
                {
                    StartCoroutine(ChargeAttack(collision.gameObject));
                }
                else
                {
                    StartCoroutine(OtterKnockback(collision.gameObject));
                }
            }
        }
    }

    IEnumerator OtterKnockback(GameObject otter)
    {
        if (otter != null)
        {
            // Calculate knockback direction
            Vector3 knockbackDirection = (otter.transform.position - transform.position).normalized;

            // Calculate target position
            Vector3 knockbackPosition = otter.transform.position + knockbackDirection * knockbackDistance;

            float elapsedTime = 0f;
            float knockbackDuration = 0.1f;

            // Move otter to knockback position smoothly
            while (elapsedTime < knockbackDuration)
            {
                otter.transform.position = Vector3.Lerp(otter.transform.position, knockbackPosition, elapsedTime / knockbackDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            otter.transform.position = knockbackPosition;
        }
    }

    IEnumerator ChargeAttack(GameObject player)
    {
        isChargingAttack = true;

        yield return new WaitForSeconds(chargeAttackDelay);

        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

        float chargeDuration = 0.2f;
        float elapsedTime = 0f;

        while (elapsedTime < chargeDuration)
        {
            transform.position += directionToPlayer * chargeSpeed * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        OtterHealth otterHealth = player.GetComponent<OtterHealth>();
        if (otterHealth != null)
        {
            otterHealth.TakeDamage(chargeAttackDamage);
            Debug.Log("Shark performed a charge attack on the player!");
        }
        else
        {
            Debug.Log("Charge attack failed - no OtterHealth component found on Player.");
        }

        attackCount = 0;
        isChargingAttack = false;
    }
}
