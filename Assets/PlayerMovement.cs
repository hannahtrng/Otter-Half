using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the player
    public Tilemap tilemap; // Reference to the Tilemap to check for border tiles
    public string borderTileName = "Tileset_37"; // The name of the border tile type (adjust as needed)
    private void Update()
    {
        // If there's no tilemap assigned, skip the check and just move the player
        if (tilemap == null)
        {
            // Move the player without checking tiles
            HandleMovementWithoutTilemap();
            return; // Exit early to prevent further execution
        }
        // Get input from horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create a movement vector based on input
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);

        // Normalize movement vector and multiply by speed
        movement = movement.normalized * speed * Time.deltaTime;

        // Check the tile the player is about to move into (next position)
        Vector3Int nextTilePosition = tilemap.WorldToCell(transform.position + movement);

        // Check if the tile at the next position is a border tile
        if (!IsBorderTile(nextTilePosition))
        {
            // Move the player if it's not a border tile
            transform.Translate(movement, Space.World);
        }
    }

    void HandleMovementWithoutTilemap()
    {
        // Get input from horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create a movement vector based on input
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);

        // Normalize movement vector and multiply by speed
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player
        transform.Translate(movement, Space.World);
    }
    bool IsBorderTile(Vector3Int position)
    {
        // Get the tile at the given position
        TileBase tile = tilemap.GetTile(position);

        // Check if the tile is not null and matches the border tile type (e.g., by name)
        if (tile != null && tile.name == borderTileName)
        {
            return true; // It's a border tile
        }

        return false; // Not a border tile
    }
}

