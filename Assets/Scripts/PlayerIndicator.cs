using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndicator : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        // Calculating the initial offset between the player and the indicator
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        // Update the position of the indicator to follow the player
        transform.position = player.transform.position + offset;
    }
}
