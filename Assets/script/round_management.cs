using Unity.VisualScripting;
using UnityEngine;

public class round_management : MonoBehaviour
{
    public float round = 1;
    public bool secondThrow = false;
    public bool resetPins = false;
    public charging charger;
    public cameraControl cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (resetPins == true)
        {
            Debug.Log("RESETING PINS");
            cam.NewRound();
        }
    }
}
