using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the player

    private void Update()
    {
        // Get input from horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create a movement vector based on input
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);

        // Normalize movement vector and multiply by speed
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player by updating its position
        transform.Translate(movement, Space.World);
    }
}

