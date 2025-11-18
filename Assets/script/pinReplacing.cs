using UnityEngine;

public class Pin : MonoBehaviour
{
    public Vector3 startPosition;
    public Quaternion startRotation;
    private bool hasFallen = false;
    [SerializeField] private GameManager gameManager; // drag in Inspector

    void Start()
    {

        // fallback if you forgot to assign
        if (gameManager == null)
        {
            gameManager = Object.FindFirstObjectByType<GameManager>();
        }
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
            }
            else
            {
                Debug.LogError("GameManager is NULL on " + gameObject.name);
            }
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
