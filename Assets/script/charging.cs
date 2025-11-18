using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using static UnityEngine.Rendering.DebugUI;

public class charging : MonoBehaviour
{
    private Slider powerSlider;
    private float charge = 0.1f;
    public float freezeCharge;
    private bool Charging;
    private bool atTop = false;
    public bool start = false;
    public rolling rolling;

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

                freezeCharge = powerSlider.value; 
                rolling.StartingRoll();
                Debug.Log("charging stopped. sending ball.");
                    powerSlider.value = 0;
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
                    
                    powerSlider.value -= 0.02f;
                }
            }
            if (atTop == true)
            {
                powerSlider.value -= 0.01f;
                if (powerSlider.value < 0.5)
                {
                    atTop = false;
                    powerSlider.value += 0.02f;
                }
            }

        }
    }
}
