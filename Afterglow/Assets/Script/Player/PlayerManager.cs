using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerLife = 20;

    [Header("tools")]
    public GameObject arc;
    public GameObject cannePeche;
    public GameObject pioche;


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
        }
        if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            arc.SetActive(true);
            cannePeche.SetActive(false);
            pioche.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            arc.SetActive(false);
            cannePeche.SetActive(true);
            pioche.SetActive(false);
        }
        if(Input.GetKeyUp(KeyCode.Alpha4))
        {
            arc.SetActive(false);
            cannePeche.SetActive(false);
            pioche.SetActive(true);
        }
    }
}
