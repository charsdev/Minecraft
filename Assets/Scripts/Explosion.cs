using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius;
    public float force;
 
    // Start is called before the first frame update
    private void Start()
    {
        DoExplosion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DoExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            var collider = colliders[i];
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

        }
    }
}
