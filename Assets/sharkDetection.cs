using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SharkMovement : MonoBehaviour
{
    public float moveSpeed;
    public float moveDistanceHoriz;  // (left-right)
    public float moveDistanceVert;   // (up-down)

    private Vector3 startPos;               // Shark's starting position
    private Vector3 targetPos;              // Target position to move towards
    private bool movingRight = true;       // True means moving to the right/up, false means moving to the left/down

    private Collider2D sharkCollider;       // Collider for shark

    // Key prefix for PlayerPrefs to track whether the shark has triggered
    private const string SharkTriggerKeyPrefix = "SharkTriggered_";

    // Unique identifier for this shark (you can use the shark's name or any unique value)
    private string sharkID;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + new Vector3(moveDistanceHoriz, moveDistanceVert, 0f);

        // Assign a unique ID based on the shark's name or other unique value
        sharkID = gameObject.name;  // Using the shark's name as the unique identifier, change this if needed.
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            FlipDirection();
        }
    }

    private void FlipDirection()
    {
        movingRight = !movingRight;

        Vector3 localScale = transform.localScale;
        localScale.x = -localScale.x;
        localScale.y = -localScale.y;
        transform.localScale = localScale;

        if (movingRight)
        {
            targetPos = startPos + new Vector3(moveDistanceHoriz, moveDistanceVert, 0f); // Move diagonally right-up
        }
        else
        {
            targetPos = startPos - new Vector3(moveDistanceHoriz, moveDistanceVert, 0f); // Move diagonally left-down
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if this shark has already been triggered (by checking PlayerPrefs for this shark's unique ID)
        if (PlayerPrefs.GetInt(SharkTriggerKeyPrefix + sharkID, 0) == 1)
        {
            return; // Exit early if this shark trigger has already been activated.
        }

        // Log and handle the first trigger
        Debug.Log("Trigger Entered");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected by shark!");

            // Mark the shark as triggered by setting the PlayerPrefs value
            PlayerPrefs.SetInt(SharkTriggerKeyPrefix + sharkID, 1); // Mark that this specific shark has triggered

            // Change scene (if necessary)
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        // Change scene (make sure the scene is added to the build settings)
        SceneManager.LoadScene("Fighting Scene");
    }

    // Reset the trigger state for all sharks
    public static void ResetAllSharkTriggers()
    {
        // You can use a naming convention or list to track all shark names
        // Example: if sharks have names like "Shark1", "Shark2", "Shark3", you can reset them in a loop.
        foreach (string sharkName in new string[] { "Shark1", "Shark2", "Shark3" })  // Example shark names
        {
            PlayerPrefs.SetInt(SharkTriggerKeyPrefix + sharkName, 0); // Reset the trigger for each shark
        }
    }
}
