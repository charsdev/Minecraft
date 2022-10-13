using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMotor : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.position += transform.TransformDirection(input) * speed * Time.deltaTime;
    }
}
