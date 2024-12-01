using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the player
    public Tilemap tilemap; // Reference to the Tilemap to check for border tiles
    public string borderTilePrefix = "Tileset_"; // The prefix of the border tiles (e.g., Tileset_)

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

        // If there's no tile, return false
        if (tile == null)
            return false;

        // Get the tile's name
        string tileName = tile.name;

        // Check if the tile name is "Tile_set23"
        if (tileName == "Tile_set23")
        {
            return true; // It's a border tile
        }

        // Check if the tile name matches the range from "Tileset_27" to "Tileset_71"
        if (tileName.StartsWith(borderTilePrefix))
        {
            // Extract the number after the prefix
            int tileNumber;
            if (int.TryParse(tileName.Substring(borderTilePrefix.Length), out tileNumber))
            {
                // Check if the number is in the range of 27 to 71
                if (tileNumber >= 27 && tileNumber <= 71)
                {
                    return true; // It's a border tile in the range Tileset_27 to Tileset_71
                }
            }
        }

        return false; // Not a border tile
    }
}
