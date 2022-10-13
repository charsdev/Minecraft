using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeper : MonoBehaviour
{
    public GameObject particle;
    public AudioClip explosionClip;
    private bool onTarget = false;
    public Transform target;


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < 5 && !onTarget)
        {
            onTarget = true;
            AudioSource audioSource = target.GetComponent<AudioSource>();

            if (audioSource)
            {
                audioSource.PlayOneShot(explosionClip);
            }

            StartCoroutine(DestroyAfter());
        }
    }

    private void OnDestroy()
    {
    }

    private IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(3.5f);
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
