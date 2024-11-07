using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SharkMovement : MonoBehaviour
{
    public float moveSpeed;           
    public float moveDistanceHoriz;  // (left-right)
    public float moveDistanceVert;   // (up-down)

    private Vector3 startPos;              
    private Vector3 targetPos;             
    private bool movingRight = true;       // true means moving to the right/up, false means moving to the left/down

    private Collider2D sharkCollider;      

    // Start is called before the first frame update
    void Start()
    {
       
        startPos = transform.position;
        // move diagonally to the right/up first
        targetPos = startPos + new Vector3(moveDistanceHoriz, moveDistanceVert, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // to target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            FlipDirection(); 
        }
    }


    private void FlipDirection()
    {
        // Reverse the moving direction
        movingRight = !movingRight;

        Vector3 localScale = transform.localScale;
        localScale.x = -localScale.x; 
        localScale.y = -localScale.y;
        transform.localScale = localScale;

        // Update the target position based on the new direction
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
        Debug.Log("Trigger Entered");  // Log to check if the trigger is being entered
        
        // Check if the object tagged as "Player" entered the trigger
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected by shark!");
            ChangeScene();
        }
       
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("Fighting Scene");
    }
}



