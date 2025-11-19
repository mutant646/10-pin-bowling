using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class activate_bumpers : MonoBehaviour
{
    [SerializeField] public Toggle check;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        check.isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (check.onToggleValueChanged)
        {
            if (!check.isOn)
            {
                transform.position += new Vector3(0, -0.3f, 0);
            }else
            {
                transform.position += new Vector3(0, +0.3f, 0);
            }
        }
    }
}
