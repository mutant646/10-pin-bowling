using UnityEngine;

using UnityEngine.UI;



public class PlayerMovement : MonoBehaviour

{
    [Header("Movement Settings")]
    public float maxPower = 20f;
    public float chargeRate = 10f;
    public float rotationSpeed = 100f;

    [Header("UI Settings")]
    public Slider powerBar;


    private Rigidbody rb;
    private float currentPower = 0f;
    private bool isCharging = false;
    private bool hasLaunched = false;

    private float minYRotation;
    private float maxYRotation;


    void Start()

    {
        rb = GetComponent<Rigidbody>();
        
        if (powerBar != null)

        {
            powerBar.minValue = 0f;
            powerBar.maxValue = maxPower;
            powerBar.value = 0f;

        }

        float startY = transform.eulerAngles.y;
        minYRotation = startY - 45f; 
        maxYRotation = startY + 45f; 

    }



    void Update()

    {

        float rotationInput = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
            rotationInput = -1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            rotationInput = 1f;

        if (!hasLaunched && rotationInput != 0f)

        {
            transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);

            Vector3 euler = transform.eulerAngles;
            euler.y = ClampAngle(euler.y, minYRotation, maxYRotation);
            transform.eulerAngles = new Vector3(euler.x, euler.y, euler.z);

        }

 

        if (!hasLaunched)
        {

            if (Input.GetKey(KeyCode.Space))
            {
                isCharging = true;
                currentPower += chargeRate * Time.deltaTime;
                currentPower = Mathf.Clamp(currentPower, 0, maxPower);

                if (powerBar != null)
                    powerBar.value = currentPower;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isCharging = false;
                LaunchBall();

            }

        }

    }


<<<<<<< Updated upstream

    void LaunchBall()

    {
        rb.AddForce(transform.forward * currentPower, ForceMode.Impulse);
        hasLaunched = true;

        if (powerBar != null)
            powerBar.value = 0f;
        currentPower = 0f;

    }

    
    float ClampAngle(float angle, float min, float max)
    {
        angle = NormalizeAngle(angle);
        min = NormalizeAngle(min);
        max = NormalizeAngle(max);

        if (angle > max)
            return max;
        if (angle < min)
            return min;
        return angle;

    }


    float NormalizeAngle(float angle)

    {
        angle = angle % 360f;
        if (angle < 0f) angle += 360f;
        return angle;

    }
=======
   
   
>>>>>>> Stashed changes

}

