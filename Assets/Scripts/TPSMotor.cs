using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSMotor : MonoBehaviour
{
    public GameObject tpsCamera;
    private float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;
    public float speed;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

        if (inputDirection != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + tpsCamera.transform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        }

        anim.SetFloat("Speed", inputDirection.magnitude);
        transform.position += transform.forward * speed * inputDirection.magnitude * Time.deltaTime;
    }

}
