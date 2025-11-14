using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class rolling : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    public charging startRoll;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  rb = GetComponent<Rigidbody>();
   startRoll = GetComponent<charging>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
        
           

   
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }


}
