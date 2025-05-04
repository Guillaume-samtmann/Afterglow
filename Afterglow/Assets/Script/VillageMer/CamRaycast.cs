using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class CamRaycast : MonoBehaviour
{
    private GameObject previousHittedObject;
    private GameObject hittedObject;
    public GameObject btnE;

    //condition
    public bool takeCane = false;
    public bool canFishing = false;

    public bool takeAxe = false;

    //ref obj
    public GameObject caneAPeche;
    public GameObject triggeurDialog1;

    public PickUpAxe scriptAxe;

    public int ptnAtt = 5;

    [Header("Rock")]
    public GameObject rock01;
    public GameObject rock02;
    public GameObject rock03;
    public GameObject rock04;
    public GameObject rock05;
    public GameObject rock06;
    public GameObject rock07;

    [Header("BoolRock")]
    public bool canBrokeRock01 = false;
    public bool canBrokeRock02 = false;
    public bool canBrokeRock03 = false;
    public bool canBrokeRock04 = false;
    public bool canBrokeRock05 = false;
    public bool canBrokeRock06 = false;
    public bool canBrokeRock07 = false;

    [Header("pvRock")]
    public int rockPv01 = 10;
    public int rockPv02 = 15;
    public int rockPv03 = 10;
    public int rockPv04 = 15;
    public int rockPv05 = 15;
    public int rockPv06 = 10;
    public int rockPv07 = 15;

    [Header("indice")]
    public GameObject indice1;
    public bool canPickupIndice1 = false;
    public bool isPickUpIndice1 = false;

    public GameObject perle1;
    public bool canPickupupPerle = false;
    public bool isPickupPerle = false;

    [Header("Wanted")]
    public GameObject wanted0;
    public bool canPickupWanted0 = false;
    public bool isPickupWanted0 = false;


    private void HighlightObject(GameObject obj, bool highlight)
    {
        Outline outiline  = obj.GetComponent<Outline>();
        if(outiline != null)
        {
            outiline.enabled = highlight;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        float raycasDistance = 1.0f;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, raycasDistance))
        {
            hittedObject = hit.transform.gameObject;

            if (hittedObject.CompareTag("peche"))
            {
                HighlightObject(hittedObject, true);
                btnE.SetActive(true);
                takeCane = true;
            }

            if (hittedObject.CompareTag("Rock"))
            {
                
                if(hittedObject.name == "Rock01")
                {
                    HighlightObject(hittedObject, true);
                    canBrokeRock01 = true;
                }
                else if (hittedObject.name == "Rock02" && scriptAxe.AxeIsTake)
                {
                    HighlightObject(hittedObject, true);
                    canBrokeRock02 = true;
                }
                else if (hittedObject.name == "Rock03" && scriptAxe.AxeIsTake)
                {
                    HighlightObject (hittedObject, true);
                    canBrokeRock03 = true;
                }
                else if (hittedObject.name == "Rock04" && scriptAxe.AxeIsTake)
                {
                    HighlightObject(hittedObject, true);
                    canBrokeRock04 = true;
                }
                else if (hittedObject.name == "Rock05" && scriptAxe.AxeIsTake)
                {
                    HighlightObject(hittedObject, true);
                    canBrokeRock05 = true;
                }
                else if (hittedObject.name == "Rock06" && scriptAxe.AxeIsTake)
                {
                    HighlightObject(hittedObject, true);
                    canBrokeRock06 = true;
                }
                else if (hittedObject.name == "Rock07" && scriptAxe.AxeIsTake)
                {
                    HighlightObject(hittedObject, true);
                    canBrokeRock07 = true;
                }
            }
            if (hittedObject.CompareTag("indice"))
            {
                if(hittedObject.name == "LettreVeillieHomme")
                {
                    HighlightObject(hittedObject, true);
                    btnE.SetActive(true);
                    canPickupIndice1 = true;
                }
                else if(hittedObject.name == "Perle")
                {
                    HighlightObject(hittedObject, true);
                    btnE.SetActive(true);
                    canPickupupPerle = true;
                }
            }
            if (hittedObject.CompareTag("Wanted"))
            {
                if(hittedObject.name == "wanted0")
                {
                    HighlightObject(hittedObject, true);
                    btnE.SetActive(true);
                    canPickupWanted0 = true;
                }
            }
        }
        else
        {
            hittedObject = null;
            takeCane=false;
            btnE.SetActive(false);
            canBrokeRock01 = false;
            canBrokeRock02 = false;
            canBrokeRock03 = false;
            canBrokeRock04 = false;
            canBrokeRock05 = false;
            canBrokeRock06 = false;
            canBrokeRock07 = false;
            canPickupIndice1 = false;
            canPickupupPerle = false;
            canPickupWanted0 = false;
        }

        if(previousHittedObject != hittedObject)
        {
            if(previousHittedObject != null)
            {
                HighlightObject(previousHittedObject, false);
            }
            previousHittedObject = hittedObject;
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && takeCane)
        {
            caneAPeche.SetActive(false);
            canFishing = true;
            btnE.SetActive(false);
            triggeurDialog1.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0) && canBrokeRock01)
        {
            rockPv01 = rockPv01 - ptnAtt;
            if (rockPv01 <= 0)
            {
                rock01.SetActive(false);
            }
        }
        if (Input.GetMouseButtonDown(0) && canBrokeRock02)
        {
            rockPv02 = rockPv02 - ptnAtt;
            if (rockPv02 <= 0)
            {
                rock02.SetActive(false);
            }
        }
        if (Input.GetMouseButtonDown(0) && canBrokeRock03)
        {
            rockPv03 = rockPv03 - ptnAtt;
            if (rockPv03 <= 0)
            {
                rock03.SetActive(false);
            }
        }
        if (Input.GetMouseButtonDown(0) && canBrokeRock04)
        {
            rockPv04 = rockPv04 - ptnAtt;
            if (rockPv04 <= 0)
            {
                rock04.SetActive(false);
            }
        }
        if (Input.GetMouseButtonDown(0) && canBrokeRock05)
        {
            rockPv05 = rockPv05 - ptnAtt;
            if (rockPv05 <= 0)
            {
                rock05.SetActive(false);
            }
        }
        if (Input.GetMouseButtonDown(0) && canBrokeRock06)
        {
            rockPv06 = rockPv06 - ptnAtt;
            if (rockPv06 <= 0)
            {
                rock06.SetActive(false);
            }
        }
        if (Input.GetMouseButtonDown(0) && canBrokeRock07)
        {
            rockPv07 = rockPv07 - ptnAtt;
            if (rockPv07 <= 0)
            {
                rock07.SetActive(false);
            }
        }
        if(Input.GetKeyUp(KeyCode.E) && canPickupIndice1)
        {
            indice1.SetActive(false);
            isPickUpIndice1 = true;
            btnE.SetActive(false);
        }
        if(Input.GetKeyUp(KeyCode.E) && canPickupupPerle)
        {
            perle1.SetActive(false);
            isPickupPerle = true;
            btnE.SetActive(false);
        }
        if(Input.GetKeyUp(KeyCode.E) && canPickupWanted0)
        {
            wanted0.SetActive(false);
            isPickupWanted0 = true;
            btnE.SetActive(false);
        }
    }
}
