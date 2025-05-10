using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneVillage : MonoBehaviour
{
    public camRayCastChampi CamRayCastChampi;
    public GameObject missingItem;

    public GameObject btnE;
    public bool canLoad = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("loadSceneVillage"))
        {
            if(CamRayCastChampi.isPickUpCarrot && CamRayCastChampi.isPickUpBottle && CamRayCastChampi.isPickUpMeat && CamRayCastChampi.isPickUpPotato && CamRayCastChampi.isPickUpLoaf && CamRayCastChampi.isPickUpArc)
            {
                btnE.SetActive(true);
                canLoad = true;
            }else
            {
                missingItem.SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("loadSceneVillage"))
        {
            if (CamRayCastChampi.isPickUpCarrot && CamRayCastChampi.isPickUpBottle && CamRayCastChampi.isPickUpMeat && CamRayCastChampi.isPickUpPotato && CamRayCastChampi.isPickUpLoaf && CamRayCastChampi.isPickUpArc)
            {
                btnE.SetActive(true);
            }
            else
            {
                missingItem.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        btnE?.SetActive(false);
        canLoad=false;
        missingItem.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && canLoad) 
        {
            SceneManager.LoadScene(1);
        }
    }
}
