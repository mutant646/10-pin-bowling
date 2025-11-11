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
    private int throwCount = 0;   
    private bool roundEnded = false;
    private Coroutine resetCoroutine;

    void Start()
    {
        ResetGame();
    }

    public void AddPinDown()
    {
        pinsDown++;
        scoreText.text = $"Pins knocked down: {pinsDown}";

        
        if (resetCoroutine != null)
        {
            StopCoroutine(resetCoroutine);
        }
        resetCoroutine = StartCoroutine(ResetAfterDelay());
    }

    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        EndThrow();
    }

    private void EndThrow()
    {
        throwCount++;

        if (pinsDown >= 10) // strike
        {
            EndRound(true);
        }
        else if (throwCount >= 2) 
        {
            EndRound(false);
        }
        else
        {
          
            ResetBall();
        }
    }

    private void EndRound(bool isStrike)
    {
        if (roundEnded) return;
        roundEnded = true;

        if (isStrike)
        {
            scoreText.text = "STRIKE!";
        }
        else
        {
            scoreText.text = $"Pins knocked down: {pinsDown}";
        }

        
        StartCoroutine(RoundResetDelay());
    }

    private IEnumerator RoundResetDelay()
    {
        yield return new WaitForSeconds(2f);
        ResetGame();
    }

    private void ResetGame()
    {
        roundEnded = false;
        pinsDown = 0;
        throwCount = 0;
        scoreText.text = "";

        ResetBall();

        foreach (Pin pin in Object.FindObjectsByType<Pin>(FindObjectsSortMode.None))
        {
            pin.ResetPin();
        }
    }

    private void ResetBall()
    {
        if (playerMovement != null && ballStartPoint != null)
        {
            Rigidbody rb = playerMovement.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            playerMovement.transform.position = ballStartPoint.position;
            playerMovement.transform.rotation = ballStartPoint.rotation;
            playerMovement.enabled = true;
        }
    }
}
