using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinite : MonoBehaviour
{

    private float length, startpos;
    public GameObject cam;

    void Start()
    {
        // keep track of the starting position of the background
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void FixedUpdate()
    {
        // get the current position of the camera
        float camX = cam.transform.position.x;

        transform.position = new Vector3(startpos, transform.position.y, transform.position.z);

        // if the camera has moved past the background's length, move the background
        if (camX > startpos + length) startpos += length;
        else if (camX < startpos - length) startpos -= length;
    }
}
