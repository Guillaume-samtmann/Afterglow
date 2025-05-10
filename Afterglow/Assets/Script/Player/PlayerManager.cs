using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerLife = 20;
    public CamRaycast camRaycast;

    [Header("tools")]
    public GameObject arc;
    public GameObject cannePeche;
    public GameObject pioche;

    [Header("activeUi")]
    public GameObject emptyActive;
    public GameObject arcActive;
    public GameObject cannePecheActive;
    public GameObject piocheActive;

    private void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Debug.Log(playerLife);
        dead();
        switchTools();
    }

    public void dead()
    {
        if(playerLife <= 0) {
            Debug.Log("perso mort");
        }
    }

    public void switchTools()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1)) {
            arc.SetActive(false);
            cannePeche.SetActive(false);
            pioche.SetActive(false);
            emptyActive.SetActive(true);
            arcActive.SetActive(false);
            cannePecheActive.SetActive(false);
            piocheActive.SetActive(false);
        }
        if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            arc.SetActive(true);
            cannePeche.SetActive(false);
            pioche.SetActive(false);
            emptyActive.SetActive(false);
            arcActive.SetActive(true);
            cannePecheActive.SetActive(false);
            piocheActive.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3) && camRaycast.canneApecheIsPickup)
        {
            arc.SetActive(false);
            cannePeche.SetActive(true);
            pioche.SetActive(false);
            emptyActive.SetActive(false);
            arcActive.SetActive(false);
            cannePecheActive.SetActive(true);
            piocheActive.SetActive(false);
        }
        if(Input.GetKeyUp(KeyCode.Alpha4) && camRaycast.piocheIsPickup)
        {
            arc.SetActive(false);
            cannePeche.SetActive(false);
            pioche.SetActive(true);
            emptyActive.SetActive(false);
            arcActive.SetActive(false);
            cannePecheActive.SetActive(false);
            piocheActive.SetActive(true);
        }
    }
}
