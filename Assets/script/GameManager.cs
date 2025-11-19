using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("References")]

    public rolling rolling;
    public Transform ballStartPoint;
    public TMP_Text scoreText;


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
        else if (pinsDown > 1)
        {
            EndRound(true);
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
        pinsDown = 0;
        throwCount = 0;
        scoreText.text = "";

        foreach (Pin pin in Object.FindObjectsByType<Pin>(FindObjectsSortMode.None))
        {
            pin.ResetPin();
        }
    }




}

