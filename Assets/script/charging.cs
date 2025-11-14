using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class charging : MonoBehaviour
{
    private Slider powerSlider;
    private float charge = 0.1f;
    private bool Charging;
    private bool atTop = false;
    public bool start = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerSlider = GetComponent<Slider>();
        powerSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
       bool spaceBarPressed = Input.GetKeyDown(KeyCode.Space);
        bool spaceBarUp = Input.GetKeyUp(KeyCode.Space);
        if (spaceBarPressed)
        {
            Charging = true;
            Debug.Log("Started charging.");
        }

        if (spaceBarUp) {
          if (charge > 0)
            {
                Charging = false;
                start = true;
                Debug.Log("charging stopped. sending ball.");
            }
        }

        if (Charging == true)
        {
            if (atTop == false)
            {
                powerSlider.value += 0.01f;
                if (powerSlider.value > 2.5)
                {
                    atTop = true;
                    Debug.Log("at top, sending down.");
                    powerSlider.value -= 0.02f;
                }
            }
            if (atTop == true)
            {
                powerSlider.value -= 0.01f;
                if (powerSlider.value < 0)
                {
                    atTop = false;
                    Debug.Log("at bottom, sending up.");
                    powerSlider.value += 0.02f;
                }
            }

        }
    }
}
