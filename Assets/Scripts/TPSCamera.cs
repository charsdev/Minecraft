using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    public Vector2 input;
    public float rotationSpeed;
    public Transform target;

    public float rotationSmoothTime = 1.2f;
    public Vector3 rotationSmoothVelocity;
    public Vector3 currentRotation;
    public float distance = 2f;
    public Vector2 limit = new Vector2(-40, 85);

    private void LateUpdate()
    {
        input += new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y")) * rotationSpeed;
        input.y = Mathf.Clamp(input.y, limit.x, limit.y);

        Vector3 targetRotation = new Vector2(input.y, input.x);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;
        transform.position = target.position - transform.forward * distance;

    }
}
