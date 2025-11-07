using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    InputAction moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 inputdirection = moveAction.ReadValue<Vector2>();
        float moveHorizontal = inputdirection.x;
        float moveVertical = inputdirection.y;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        float angle = Mathf.Atan2(moveVertical, moveHorizontal) * Mathf.Rad2Deg;
        Vector3 rotation = new Vector3(0, -angle + 90, 0); //rotate around the z-axis
        transform.eulerAngles = rotation;
    }
}
