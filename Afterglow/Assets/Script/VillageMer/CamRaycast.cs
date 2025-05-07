using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class CamRaycast : MonoBehaviour
{
    private GameObject previousHittedObject;
    private GameObject hittedObject;
    [Header("Button_E")]
    public GameObject btnE_wanted;
    public GameObject btnE_cane;
    public GameObject btnE;
    public GameObject btnE_pioche;
    public GameObject btnClicGauche;

    //condition
    public bool takeCane = false;
    public bool canFishing = false;
    public bool canneApecheIsPickup = false;

    public bool takeAxe = false;

    //ref obj
    public GameObject caneAPeche;
    public GameObject triggeurDialog1;

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
    public GameObject btnPerle;

    [Header("Wanted")]
    public GameObject wanted0;
    public bool canPickupWanted0 = false;
    public bool isPickupWanted0 = false;

    [Header("pioche")]
    public bool canPickuupPioche = false;
    public bool piocheIsPickup = false;
    public GameObject pioche;
    public GameObject piocheUser;
    public Animator animatorPioche;

    [Header("uiItem")]
    public GameObject cannePecheUi;
    public GameObject piocheUi;


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
                btnE_cane.SetActive(true);
                takeCane = true;
            }

            if (hittedObject.CompareTag("Rock"))
            {
                
                if(hittedObject.name == "Rock01" && piocheIsPickup)
                {
                    if (piocheUser.activeInHierarchy)
                    {
                        HighlightObject(hittedObject, true);
                        canBrokeRock01 = true;
                        btnClicGauche.SetActive(true);
                    }else
                    {
                        Debug.Log("Il faut une pioche");
                    }
                }
                else if (hittedObject.name == "Rock02" && piocheIsPickup)
                {
                    HighlightObject(hittedObject, true);
                    canBrokeRock02 = true;
                    btnClicGauche.SetActive(true);
                }
                else if (hittedObject.name == "Rock03" && piocheIsPickup)
                {
                    HighlightObject (hittedObject, true);
                    canBrokeRock03 = true;
                    btnClicGauche.SetActive(true);
                }
                else if (hittedObject.name == "Rock04" && piocheIsPickup)
                {
                    if (piocheUser.activeInHierarchy)
                    {
                        HighlightObject(hittedObject, true);
                        canBrokeRock04 = true;
                        btnClicGauche.SetActive(true);
                    }else
                    {
                        Debug.Log("Il faut une pioche");
                    }
                }
                else if (hittedObject.name == "Rock05" && piocheIsPickup)
                {
                    HighlightObject(hittedObject, true);
                    canBrokeRock05 = true;
                    btnClicGauche.SetActive(true);
                }
                else if (hittedObject.name == "Rock06" && piocheIsPickup)
                {
                    HighlightObject(hittedObject, true);
                    canBrokeRock06 = true;
                    btnClicGauche.SetActive(true);
                }
                else if (hittedObject.name == "Rock07" && piocheIsPickup)
                {
                    HighlightObject(hittedObject, true);
                    canBrokeRock07 = true;
                    btnClicGauche.SetActive(true);
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
                    btnPerle.SetActive(true);
                    canPickupupPerle = true;
                }
            }
            if (hittedObject.CompareTag("Wanted"))
            {
                if(hittedObject.name == "wanted0")
                {
                    HighlightObject(hittedObject, true);
                    btnE_wanted.SetActive(true);
                    canPickupWanted0 = true;
                }
            }
            if (hittedObject.CompareTag("Pioche"))
            {
                HighlightObject(hittedObject, true);
                btnE_pioche.SetActive(true);
                canPickuupPioche = true;
            }
        }
        else
        {
            hittedObject = null;
            takeCane=false;
            btnE.SetActive(false);
            btnE_cane.SetActive(false);
            btnE_wanted.SetActive(false);
            btnE_pioche.SetActive(false);
            btnPerle.SetActive(false);
            btnClicGauche.SetActive(false);
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
            btnE_cane.SetActive(false);
            triggeurDialog1.SetActive(false);
            cannePecheUi.SetActive(true);
            canneApecheIsPickup = true;
        }
        if (Input.GetMouseButtonDown(0) && canBrokeRock01)
        {
            rockPv01 = rockPv01 - ptnAtt;
            animatorPioche.SetBool("IsUse", true);
            if (rockPv01 <= 0)
            {
                rock01.SetActive(false);
            }
        }
        if (Input.GetMouseButtonDown(0) && canBrokeRock02)
        {
            rockPv02 = rockPv02 - ptnAtt;
            animatorPioche.SetBool("IsUse", true);
            if (rockPv02 <= 0)
            {
                rock02.SetActive(false);
            }
        }
        if (Input.GetMouseButtonDown(0) && canBrokeRock03)
        {
            rockPv03 = rockPv03 - ptnAtt;
            animatorPioche.SetBool("IsUse?", true);
            if (rockPv03 <= 0)
            {
                rock03.SetActive(false);
            }
        }
        if (Input.GetMouseButtonDown(0) && canBrokeRock04)
        {
            rockPv04 = rockPv04 - ptnAtt;
            animatorPioche.SetBool("IsUse", true);
            if (rockPv04 <= 0)
            {
                rock04.SetActive(false);
            }
        }
        if (Input.GetMouseButtonDown(0) && canBrokeRock05)
        {
            rockPv05 = rockPv05 - ptnAtt;
            animatorPioche.SetBool("IsUse", true);
            if (rockPv05 <= 0)
            {
                rock05.SetActive(false);
            }
        }
        if (Input.GetMouseButtonDown(0) && canBrokeRock06)
        {
            rockPv06 = rockPv06 - ptnAtt;
            animatorPioche.SetBool("IsUse", true);
            if (rockPv06 <= 0)
            {
                rock06.SetActive(false);
            }
        }
        if (Input.GetMouseButtonDown(0) && canBrokeRock07)
        {
            rockPv07 = rockPv07 - ptnAtt;
            animatorPioche.SetBool("IsUse", true);
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
            btnPerle.SetActive(false);
        }
        if(Input.GetKeyUp(KeyCode.E) && canPickupWanted0)
        {
            wanted0.SetActive(false);
            isPickupWanted0 = true;
            btnE_wanted.SetActive(false);
        }
        if(Input.GetKeyUp(KeyCode.E) && canPickuupPioche)
        {
            pioche.SetActive(false);
            piocheIsPickup = true;
            btnE_pioche.SetActive(false);
            piocheUi.SetActive(true);
        }
    }
}
