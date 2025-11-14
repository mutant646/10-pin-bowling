using UnityEngine;
using UnityEngine.UI;

public class charging : MonoBehaviour
{
    public Slider powerSlider;
    public float charge = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    Slider powerSlider = GetComponent("powerSlider") as Slider;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            while (Input.GetKeyDown(KeyCode.Space) == true)
            {
                charge = charge + 0.05f;
                if (charge > 2.5)
                {
                    charge = 0;
                }
                powerSlider.value = charge;
            }
        }
    }
}
