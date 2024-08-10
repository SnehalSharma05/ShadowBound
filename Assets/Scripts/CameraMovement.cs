using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform; // Assign this in the inspector with your player's transform
    public float xOffset; // You can adjust this in the inspector to set how far back the camera should be from the player on the x-axis

    void LateUpdate()
    {
        // Check if the player exists to avoid errors if the player is not assigned or destroyed
        if (playerTransform != null)
        {
            // Set the camera's position to follow the player's x position with the specified offset
            // Keep the camera's current y and z positions
            transform.position = new Vector3(playerTransform.position.x + xOffset, transform.position.y, transform.position.z);
        }
    }
}
