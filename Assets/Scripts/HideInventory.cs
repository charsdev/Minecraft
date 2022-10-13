using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInventory : MonoBehaviour
{
    public GameObject inventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeInHierarchy);
        }    
    }
}
