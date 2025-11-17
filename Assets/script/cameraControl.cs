using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public GameObject bowlingBall;
    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - bowlingBall.transform.position;
    }

    // Update is called once per frame
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
