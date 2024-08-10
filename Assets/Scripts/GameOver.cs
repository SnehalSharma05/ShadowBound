using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject player, shadow, gameOver, restart;
    private void Start()
    {
        restart.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        // if the game over screen is active, stop the player and shadow from moving
        if (gameOver.transform.lossyScale.x > 0) {

            PlayerMovement MoveScript = player.GetComponent<PlayerMovement>();
            ShadowMovement ShadowMoveScript = shadow.GetComponent<ShadowMovement>();
            MoveScript.enabled = false;
            ShadowMoveScript.enabled = false;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            shadow.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            restart.SetActive(true);
        }

    }
}
