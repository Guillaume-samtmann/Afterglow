using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    private int arrowDamage = 25;
    private bool isStuck = false;
    public string toucher;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Meilleure dur�e de vie pour �viter la destruction pr�matur�e
        Destroy(gameObject, 10f);

        // Ignore les collisions avec le joueur
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

        // Assure des collisions pr�cises
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isStuck && !collision.transform.CompareTag("Player"))
        {
            isStuck = true;

            //rb.velocity = Vector3.zero;
            //rb.angularVelocity = Vector3.zero;
            //rb.isKinematic = true;

            GetComponent<Collider>().enabled = false;

            toucher = collision.transform.name;
            Debug.Log("Fleche touch�e : " + toucher);
        }
    }
}
