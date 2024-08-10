using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSound : MonoBehaviour
{
    void Start()
    {
        // Disables the audio source component in the beginning
        transform.GetComponent<AudioSource>().enabled=false;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player collides with the object, the audio source component is enabled
        if (collision.gameObject.tag == "Player")
        {
            transform.GetComponent<AudioSource>().enabled=true;
        }
    }
}
