using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePower : MonoBehaviour
{
    public GameObject shadow, player, teleportSound;

    public void Start()
    {
        teleportSound.SetActive(false);
    }

    // Detects collision with the player and teleports the shadow to the player's position
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            teleportSound.SetActive(true);
            gameObject.SetActive(false);
            shadow.transform.position = new Vector3(player.transform.position.x, shadow.transform.position.y, shadow.transform.position.z);

        }

    }
}
