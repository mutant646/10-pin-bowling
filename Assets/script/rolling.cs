using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UIElements;

public class rolling : MonoBehaviour
{
    public Pin pins;
    public cameraControl cam;
    public round_management management;
    public charging charging;
    public float speed = 0;
    private Rigidbody rb;
    float AngleY = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
  void Update()
    {
        if (speed == 0)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                if (AngleY > -0.3f)
                {
                    AngleY -= 0.003f;
                    transform.Rotate(new Vector3(0, -0.5f, 0));
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(-6.619f, 0.108f, transform.position.z + 0.0001f);
            }
            if (Input.GetKey(KeyCode.E))
            {
                if (AngleY < 0.3f)
                {
                    AngleY += 0.003f;
                    transform.Rotate(new Vector3(0, 0.5f, 0));
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(-6.619f, 0.108f, transform.position.z - 0.0001f);
            }
        }
    }
   public IEnumerator NextThrow()
    {
        yield return new WaitForSeconds(10);
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = new Vector3(-6.619f, 0.108f, 0);

        if (management.secondThrow == true)
        {
            management.secondThrow = false;
            management.round++;
            management.resetPins = true;
        }
        else if (pins.pinsDown == 10)
        {
            management.secondThrow = false;
            management.round++;
            management.resetPins = true;
        }
        else 
        { management.secondThrow = true;
           
            cam.transform.position = transform.position + cam.offset;
            speed = 0;
        }
        charging.powerSlider.value = 0;
    }
    public void StartingRoll()
    {
        speed = charging.freezeCharge;           
            Debug.Log("start recieved, sending vector now.");
            Vector3 bowl = new Vector3(150, 0, (-AngleY * 150));
        Debug.Log(bowl);
        Debug.Log(speed);
        rb.AddForce(bowl * speed * 10);
            Debug.Log("Vector applied.");
        StartCoroutine(NextThrow());
       
    }    
        
           

   
    private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(-10, 0, 0);
    }
    

}
