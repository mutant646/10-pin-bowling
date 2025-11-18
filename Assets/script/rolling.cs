using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UIElements;

public class rolling : MonoBehaviour
{
    public charging charging;
    private float speed = 0;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartingRoll()
    {
        speed = charging.freezeCharge;           
            Debug.Log("start recieved, sending vector now.");
            Vector3 bowl = new Vector3(1500, 0, 750);
        Debug.Log(bowl);
        Debug.Log(speed);
        rb.AddForce(bowl * speed);
            Debug.Log("Vector applied.");     
         
       
    }    
        
           

   
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }


}
