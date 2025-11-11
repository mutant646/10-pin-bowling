using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public PlayerMovement playerMovement;  
    public Transform ballStartPoint;      
    public Text scoreText;                

    private int pinsDown = 0;
    private bool roundEnded = false;

    void Start()
    {
        ResetGame();
    }

    public void AddPinDown()
    {
        pinsDown++;

        // check if pins have fallen
        if (pinsDown >= 10 && !roundEnded)
        {
            StartCoroutine(EndRound(true));
        }
    }

    public IEnumerator EndRound(bool isStrike = false)
    {
        roundEnded = true;

        if (isStrike)
        {
            scoreText.text = "STRIKE!";
        }
        else
        {
            scoreText.text = $"Pins knocked down: {pinsDown}";
        }

        yield return new WaitForSeconds(2f);
        ResetGame();
    }

    private void ResetGame()
    {
        roundEnded = false;
        pinsDown = 0;
        scoreText.text = "";


        if (playerMovement != null && ballStartPoint != null)
        {
            Rigidbody rb = playerMovement.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            playerMovement.transform.position = ballStartPoint.position;
            playerMovement.transform.rotation = ballStartPoint.rotation;

            playerMovement.enabled = true; 
        }


        foreach (Pin pin in Object.FindObjectsByType<Pin>(FindObjectsSortMode.None))
        {
            pin.ResetPin();
        }

    }
}