using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCollision : MonoBehaviour
{
    public GameObject text;
    public GameObject screen;
    private void Start()
    {
        screen.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the player collides with the object, the instruction text and video are displayed
        text.GetComponent<Animator>().SetTrigger("FirstCollision");
        screen.SetActive(true);
    }
    
}
