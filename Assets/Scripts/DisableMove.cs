using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableMove : MonoBehaviour, IPointerClickHandler
{
    public GameObject player,shadow,logo;
    public GameObject Instructions, PlayerIndicator, ShadowIndicator, startSound;
    public GameObject Title;
    private void Start()
    {
        // if the initial screen is active, stop the player and shadow from moving
        PlayerMovement MoveScript = player.GetComponent<PlayerMovement>();
        ShadowMovement ShadowMoveScript = shadow.GetComponent<ShadowMovement>();
        Instructions.SetActive(false);
        PlayerIndicator.SetActive(false);
        ShadowIndicator.SetActive(false);
        startSound.SetActive(false);
        MoveScript.enabled = false;
        ShadowMoveScript.enabled = false;
    }
    public void Update()
    {
        // if any key is pressed, the initial screen fades out and the game starts
        if (Input.anyKey) {
            logo.GetComponent<Animator>().SetTrigger("FadeOut");
            PlayerMovement MoveScript = player.GetComponent<PlayerMovement>();
            ShadowMovement ShadowMoveScript = shadow.GetComponent<ShadowMovement>();
            Instructions.SetActive(true);
            PlayerIndicator.SetActive(true);
            ShadowIndicator.SetActive(true);
            startSound.SetActive(true);
            MoveScript.enabled = true;
            ShadowMoveScript.enabled = true;
            Title.SetActive(false);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // if the screen is clicked, the initial screen fades out and the game starts
        logo.GetComponent<Animator>().SetTrigger("FadeOut");
        PlayerMovement MoveScript = player.GetComponent<PlayerMovement>();
        ShadowMovement ShadowMoveScript = shadow.GetComponent<ShadowMovement>();
        Instructions.SetActive(true);
        PlayerIndicator.SetActive(true);
        ShadowIndicator.SetActive(true);
        startSound.SetActive(true);
        MoveScript.enabled = true;
        ShadowMoveScript.enabled = true;
        Title.SetActive(false);
    }
}