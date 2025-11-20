using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public GameObject bowlingBall;
    public Vector3 offset;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - bowlingBall.transform.position;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
     
        }
        if (Input.GetKeyDown(KeyCode.D))
        {

        }

    }
    public void NewRound()
    {
        transform.position = bowlingBall.transform.position + offset;
    }
    void LateUpdate()
    {
       
        if (transform.position.x > 0.4)
        {

        }
        else
        {
            transform.position = bowlingBall.transform.position + offset;
        }
    } 
}
