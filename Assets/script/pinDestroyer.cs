using UnityEngine;

public class pinControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yAngle = transform.eulerAngles.y;
        if (yAngle != 0.013) {
            void WaitForSeconds(5);
        }
  
    }
}
