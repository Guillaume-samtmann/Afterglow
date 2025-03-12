using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveBoat : MonoBehaviour
{
    public float speed = 5f;
    private bool canDriveBoat = false;
    private bool isDriving = false;
    public GameObject boat;
    public GameObject player;
    public Transform playerCamera; // 🎯 Ajouter la caméra du joueur
    private CharacterController playerController;
    private Rigidbody playerRigidbody;

    private void Start()
    {
        // Récupérer les composants du joueur
        playerController = player.GetComponent<CharacterController>();
        playerRigidbody = player.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DriveBoat"))
        {
            canDriveBoat = true;
            Debug.Log("Tu peux piloter le bateau");
        }
    }

    void Update()
    {
        if (canDriveBoat)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDriving();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StopDriving();
            }
        }

        if (isDriving)
        {
            MoveBoat(); // Déplacement du bateau avec orientation de la caméra
        }
    }

    private void StartDriving()
    {
        isDriving = true;

        // Rendre le joueur enfant du bateau
        player.transform.SetParent(boat.transform);

        // Désactiver les déplacements du joueur
        if (playerRigidbody != null)
        {
            playerRigidbody.useGravity = false;
            playerRigidbody.isKinematic = true;
        }
        if (playerController != null)
        {
            playerController.enabled = false;
        }

        Debug.Log("Tu pilotes le bateau !");
    }

    private void StopDriving()
    {
        isDriving = false;

        // Retirer le joueur du bateau
        player.transform.SetParent(null);

        // Réactiver les déplacements du joueur
        if (playerRigidbody != null)
        {
            playerRigidbody.useGravity = true;
            playerRigidbody.isKinematic = false;
        }
        if (playerController != null)
        {
            playerController.enabled = true;
        }

        Debug.Log("Tu as quitté le bateau !");
    }

    private void MoveBoat()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.Z))
            moveZ = 1f;
        if (Input.GetKey(KeyCode.S))
            moveZ = -1f;
        if (Input.GetKey(KeyCode.Q))
            moveX = -1f;
        if (Input.GetKey(KeyCode.D))
            moveX = 1f;

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized * speed * Time.deltaTime;

        // 🎯 Appliquer l'orientation de la caméra
        if (playerCamera != null)
        {
            Vector3 cameraForward = playerCamera.forward;
            cameraForward.y = 0; // On évite de prendre l'inclinaison de la caméra
            movement = Quaternion.LookRotation(cameraForward) * movement;
        }

        // Déplacer le bateau (et donc le joueur avec)
        boat.transform.Translate(movement, Space.World);
    }
}






