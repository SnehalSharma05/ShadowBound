using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player, shadow, cam, DamageOverlay, healthFrame, healthBar, gameOver;
    public float ShadowThreshold = 5f;
    private float playerX, shadowX;
    [SerializeField]
    private AudioSource healthBarAudioSource; // Add a reference to the AudioSource component

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        healthBarAudioSource.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerX = player.transform.position.x;
        shadowX = shadow.transform.position.x;
        if ((Mathf.Abs(playerX - shadowX) > ShadowThreshold) || player.transform.position.y < 0 || shadow.transform.position.y > 0)
        {
            // if the player and shadow are too far apart, start game over countdown
            healthBarAudioSource.enabled = true;
            DamageOverlay.GetComponent<Animator>().SetBool("TakingDamage", true);
            healthBar.GetComponent<Animator>().SetBool("TakingDamage", true);
            healthFrame.GetComponent<Animator>().SetBool("TakingDamage", true);
            gameOver.SetActive(true);
            gameOver.GetComponent<Animator>().SetBool("GameOver", true);
        }
        else
        {
            // if the player and shadow are close enough, stop the game over countdown
            healthBarAudioSource.enabled = false;
            DamageOverlay.GetComponent<Animator>().SetBool("TakingDamage", false);
            healthBar.GetComponent<Animator>().SetBool("TakingDamage", false);
            healthFrame.GetComponent<Animator>().SetBool("TakingDamage", false);
            gameOver.GetComponent<Animator>().SetBool("GameOver", false);
            gameOver.SetActive(false);
        }
    }
}
