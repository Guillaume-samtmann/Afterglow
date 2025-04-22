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
                Debug.Log("casser cailloux");
            }
        }
        else
        {
            hittedObject = null;
            takeCane=false;
            btnE.SetActive(false);
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

        if(Input.GetKeyDown(KeyCode.E) && takeCane)
        {
            caneAPeche.SetActive(false);
            canFishing = true;
            btnE.SetActive(false);
            triggeurDialog1.SetActive(false);
        }
    }
}
