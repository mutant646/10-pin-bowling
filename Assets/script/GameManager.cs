using UnityEngine;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
using UnityEngine.UI;
=======
using TMPro;
>>>>>>> Stashed changes
=======
using TMPro;
>>>>>>> Stashed changes
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("References")]
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public PlayerMovement playerMovement;
    public Transform ballStartPoint;
    public Text scoreText;
=======
    public rolling  rolling;
    public Transform ballStartPoint;
    public TMP_Text scoreText;
>>>>>>> Stashed changes
=======
    public rolling  rolling;
    public Transform ballStartPoint;
    public TMP_Text scoreText;
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
<<<<<<< Updated upstream

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
          
=======
        {
            EndRound(true);

>>>>>>> Stashed changes
=======
        {
            EndRound(true);

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        if (playerMovement != null && ballStartPoint != null)
        {
            Rigidbody rb = playerMovement.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            playerMovement.transform.position = ballStartPoint.position;
            playerMovement.transform.rotation = ballStartPoint.rotation;
            playerMovement.enabled = true;
=======
=======
>>>>>>> Stashed changes
        if (rolling != null && ballStartPoint != null)
        {
            Rigidbody rb = rolling.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rolling.transform.position = ballStartPoint.position;
            rolling.transform.rotation = ballStartPoint.rotation;
            rolling.enabled = true;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        }
    }
}
