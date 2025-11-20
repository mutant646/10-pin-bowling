using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public int pinsDown;
    public round_management Manager;
    public Vector3 startPosition;
    public Quaternion startRotation;
    private bool hasFallen = false;
    [SerializeField] private GameManager gameManager; // drag in Inspector
    


    public rolling bowlingBall;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

        // fallback if you forgot to assign
        if (gameManager == null)
        {
            gameManager = Object.FindFirstObjectByType<GameManager>();
        }
       
    }

    private IEnumerator SpawnDelay()
    {
        Debug.Log("start waiting");
        yield return new WaitForSeconds(3);
        Debug.Log("waiting done");
        transform.position = startPosition + new Vector3(-4f, 0.0f, 0.0f);
        transform.rotation = startRotation;
    }
    void Update()
    {

        if (!hasFallen && transform.up.y < 0.5f)
        {
            hasFallen = true;
            
            Debug.Log($"{gameObject.name} fell over"); // confirm detection

            
            if (gameManager != null)
            {
                gameManager.AddPinDown();
                pinsDown++;
                Debug.Log(pinsDown);  
            }
            StartCoroutine(SpawnDelay());
            
        }



        if (Manager.resetPins == true)
        {
            Debug.Log("check check");
            hasFallen = false;
            pinsDown = 0;
            for (int i = 1; i < 11; i++) {
                transform.position = startPosition;
            transform.rotation = startRotation;
        }
            
            Manager.resetPins = false;
        }
    }
}
