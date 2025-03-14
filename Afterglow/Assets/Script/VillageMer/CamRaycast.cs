using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRaycast : MonoBehaviour
{
    private GameObject previousHittedObject;
    private GameObject hittedObject;

    //condition
    public bool takeCane = false;
    public bool canFishing = false;

    //ref obj
    public GameObject caneAPeche;

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
                Debug.Log("E");
                takeCane = true;
            }
        }
        else
        {
            hittedObject = null;
            takeCane=false;
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
        }
    }
}
