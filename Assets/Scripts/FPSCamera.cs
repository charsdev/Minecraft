using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float speed;
    private Vector3 rotation;
    public  float angle = 70;
    public Transform character;
    public Transform hideArm;

    private void OnEnable()
    {
        hideArm.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        hideArm.gameObject.SetActive(true);
    }

    private void Update()
    {
        rotation += new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * speed * Time.deltaTime;
        rotation.y = Mathf.Clamp(rotation.y, -angle, angle);
        transform.localRotation = Quaternion.Euler(-rotation.y, 0f, 0f);
        character.rotation = Quaternion.Euler(0f, rotation.x, 0f);
    }
}
