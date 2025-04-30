using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    private int arrowDamage = 25;
    private bool isStuck = false;
    public string toucher;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 3f);

        Collider arrowCollider = GetComponent<Collider>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Collider[] playerColliders = player.GetComponentsInChildren<Collider>();
            foreach (Collider playerCollider in playerColliders)
            {
                Physics.IgnoreCollision(arrowCollider, playerCollider);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isStuck && !collision.transform.CompareTag("Player"))
        {
            isStuck = true;

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            rb.isKinematic = true;

            toucher = collision.transform.name;
            GetComponent<Collider>().enabled = false;

            Debug.Log(toucher);
        }
    }
}
