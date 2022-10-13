using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject fpsCamera;
    public GameObject tpsCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            tpsCamera.SetActive(!tpsCamera.activeInHierarchy);
            fpsCamera.SetActive(!fpsCamera.activeInHierarchy);
        }
    }
}
