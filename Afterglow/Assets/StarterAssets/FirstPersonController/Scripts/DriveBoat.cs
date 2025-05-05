using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveBoat : MonoBehaviour
{
    //ref
    public CamRaycast camRaycast;
    //variable
    public float speed = 5f;
    private bool canDriveBoat = false;
    public bool isDriving = false;
    public GameObject boat;
    public GameObject player;
    public GameObject playerParent;
    public Transform playerCamera; // 🎯 Ajouter la caméra du joueur
    private CharacterController playerController;
    private Rigidbody playerRigidbody;
    public GameObject btnE;
    public GameObject cmdDrive;

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
            btnE.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("DriveBoat"))
        {
            btnE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DriveBoat"))
        {
            canDriveBoat = false;
        }
    }

    void Update()
    {
        if (camRaycast.canFishing == true)
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
        else
        {
            //Debug.Log("tu n'as pas de cane a peche");
        }
        
    }

    private void StartDriving()
    {
        isDriving = true;

        // Rendre le joueur enfant du bateau
        player.transform.SetParent(boat.transform, true);
        //player.transform.localScale = Vector3.one;

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
        cmdDrive.SetActive(true);

    }

    private void StopDriving()
    {
        isDriving = false;

        // Retirer le joueur du bateau
        player.transform.SetParent(null, true);
        player.transform.SetParent(playerParent.transform, true);
        player.transform.localScale = Vector3.one;

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
        cmdDrive.SetActive(false);
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






