using UnityEngine;

public class CameraFollowBallRotation : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    private bool isPaused = false;

    void LateUpdate()
    {
        if (target == null) return;

        if (Input.GetKey(KeyCode.Space))
            isPaused = true;

        if (!isPaused)
        {
            Quaternion targetYaw = Quaternion.Euler(transform.eulerAngles.x, target.eulerAngles.y, transform.eulerAngles.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetYaw, smoothSpeed * Time.deltaTime);
        }
    }
}