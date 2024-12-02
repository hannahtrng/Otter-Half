using UnityEngine;

public class SharkMovement2 : MonoBehaviour
{
    public Transform otter;
    public float speed = 2f;

    void Update()
    {
        if (otter != null)
        {
            // Move toward the otter
            Vector2 direction = ((Vector2)otter.position - (Vector2)transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, otter.position, speed * Time.deltaTime);

            // Flip the shark to face the otter
            if (otter.position.x > transform.position.x)
            {
                // Face left
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                // Face right
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
