using UnityEngine;

public class OtterController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isSwimmingLeft = false; // Tracks the current direction
    private bool isTurning = false; // Tracks if the otter is in the turning state

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set default animator parameters
        if (animator != null)
        {
            animator.SetBool("isSwimming", false);
            animator.SetBool("isSwimmingLeft", isSwimmingLeft);
            // animator.SetBool("isTurning", false);
        }
        else
        {
            Debug.LogError("Animator component not found on Otter GameObject.");
        }

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on Otter GameObject.");
        }
    }

    void Update()
    {
        if (animator == null) return; // Exit if animator is missing

        // Block input during turn animation
        if (isTurning) return;

        // Handle movement input specifically for the otter
        HandleOtterMovement();
    }

    private void HandleOtterMovement()
    {
        // Swim left
        if (Input.GetKey(KeyCode.A))
        {
            if (!isSwimmingLeft && !isTurning) // Trigger turn animation only if switching from right
            {
                StartTurn(true);
            }
            else if (!animator.GetBool("isSwimming")) // Start swimming directly if already facing left
            {
                StartSwimming(true);
            }
        }
        // Swim right
        else if (Input.GetKey(KeyCode.D))
        {
            if (isSwimmingLeft && !isTurning) // Trigger turn animation only if switching from left
            {
                StartTurn(false);
            }
            else if (!animator.GetBool("isSwimming")) // Start swimming directly if already facing right
            {
                StartSwimming(false);
            }
        }
        // Go idle when no keys are pressed
        else
        {
            if (!isTurning && animator.GetBool("isSwimming")) // Stop swimming when not turning
            {
                StopSwimming();
            }
        }
    }

    private void StartTurn(bool turnLeft)
    {
        if (isSwimmingLeft == turnLeft) return; // Skip if already facing the correct direction

        // isTurning = true; // Mark as turning
        isSwimmingLeft = turnLeft;

        // Update Animator parameters
        animator.SetBool("isSwimmingLeft", isSwimmingLeft);
        animator.SetTrigger("turn");

        Debug.Log("Turning to " + (turnLeft ? "left" : "right"));
        if (SFXmanager.Instance != null && SFXmanager.Instance.TurnSound != null)
        {
            SFXmanager.Instance.TurnSound.Play();
        }

        // Use turn animation
        // spriteRenderer.flipX = turnLeft;
        // moved to OnOtterTurn

        // Finish the turn after the turn animation duration
        // float turnDuration = 0.5f; // Adjust based on the length of turn animation
        // Invoke("FinishTurn", turnDuration);
    }

    private void FinishTurn()
    {
        // no longer being used, changed parameter to trigger "turn"
        isTurning = false; // Mark turn as finished
        animator.SetBool("isTurning", false);

        Debug.Log("Turn completed.");
    }

    private void StartSwimming(bool swimLeft)
    {
        isSwimmingLeft = swimLeft;

        // Update Animator parameters
        if (SFXmanager.Instance != null && SFXmanager.Instance.MovementSound != null)
        {
            SFXmanager.Instance.MovementSound.Play();
        }
        animator.SetBool("isSwimming", true);
        animator.SetBool("isSwimmingLeft", isSwimmingLeft);

        Debug.Log("Swimming " + (swimLeft ? "left" : "right"));
    }

    private void StopSwimming()
    {
        animator.SetBool("isSwimming", false);
        Debug.Log("Idle");
    }

    public void OnOtterTurn()
    {
        // Use turn animation
        spriteRenderer.flipX = isSwimmingLeft;
    }
}

