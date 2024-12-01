using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtterAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public float attackRange = 1.5f;
    public float horizontalOffset = 1.0f;
    public float verticalOffset = 0.0f;
    public float knockbackDistance = 1.0f; // Distance for shark knockback
    public float knockbackDuration = 0.1f; // Duration of knockback
    public KeyCode attackKey = KeyCode.Space;
    public LayerMask sharkLayer;
    private Animator animator;

    private bool facingRight = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       // UpdateFacingDirection();

        if (Input.GetKeyDown(attackKey))
        {
            Attack();
        }
    }

    // void UpdateFacingDirection()
    // {
    //     if (Input.GetKey(KeyCode.A))
    //     {
    //         facingRight = false;
    //         FlipSprite(-1);
    //     }
    //     else if (Input.GetKey(KeyCode.D))
    //     {
    //         facingRight = true;
    //         FlipSprite(1);
    //     }
    // }

    void FlipSprite(int direction)
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
    }

    void Attack()
    {
        animator.SetTrigger("attack");
        Vector2 attackPosition = CalculateAttackPosition();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPosition, attackRange, sharkLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject == gameObject) continue;

            Debug.Log("Detected GameObject: " + enemy.gameObject.name);

            SharkHealth sharkHealth = enemy.GetComponent<SharkHealth>();
            if (sharkHealth != null)
            {
                sharkHealth.TakeDamage(attackDamage);
                StartCoroutine(ApplyKnockback(enemy.gameObject));
                Debug.Log("Otter attacked the shark!");
            }
            else
            {
                Debug.Log("Shark detected, but no SharkHealth component found on: " + enemy.gameObject.name);
            }
        }
    }

    IEnumerator ApplyKnockback(GameObject shark)
    {
        Vector3 knockbackDirection = (shark.transform.position - transform.position).normalized;
        Vector3 knockbackTarget = shark.transform.position + knockbackDirection * knockbackDistance;

        float elapsedTime = 0f;

        while (elapsedTime < knockbackDuration)
        {
            shark.transform.position = Vector3.Lerp(shark.transform.position, knockbackTarget, elapsedTime / knockbackDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        shark.transform.position = knockbackTarget;
    }

    private Vector2 CalculateAttackPosition()
    {
        float horizontalAdjustment = facingRight ? horizontalOffset : -horizontalOffset;
        return new Vector2(transform.position.x + horizontalAdjustment, transform.position.y + verticalOffset);
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 attackPosition = CalculateAttackPosition();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition, attackRange);
    }
}

