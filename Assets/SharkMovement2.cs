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
        }
    }
}
