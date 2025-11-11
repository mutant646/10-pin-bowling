using UnityEngine;



public class Pin : MonoBehaviour

{

    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool hasFallen = false;
    private GameManager gameManager;



    void Start()

    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        gameManager = Object.FindFirstObjectByType<GameManager>();

    }

    void Update()

    {

        if (!hasFallen && transform.up.y < 0.5f) // check if pin is tipped over

        {
            hasFallen = true;
            gameManager.AddPinDown();

        }

    }

    public void ResetPin()

    {

        hasFallen = false;
        transform.position = startPosition;
        transform.rotation = startRotation;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

    }

}