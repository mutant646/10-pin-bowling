using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class rolling : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool spaceBarDown = Input.GetKeyDown(KeyCode.Space);
        
        Vector3 movement = new Vector3(1, 0.0f, 0.0f);
        
        rb.AddForce(speed * movement);
     
        
        if (spaceBarDown == true)
        {
            speed = 1.5f;     
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }


}
