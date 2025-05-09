using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class camRayCastChampi : MonoBehaviour
{
    private GameObject previousHittedObject;
    private GameObject hittedObject;
    [Header("Button_E")]
    public GameObject btnE_bag;
    public GameObject btnE_food;
    public GameObject btnE;
    public GameObject btnE_money;

    [Header("Items")]
    public GameObject bag;
    public GameObject money;
    public GameObject food;

    public bool canPickUpBag = false;
    public bool canPickUpMoney = false;
    public bool canPickUpFood = false;

    public bool isPickUpBag = false;
    public bool isPickUpMoney = false;
    public bool isPickUpFood = false;
    private void HighlightObject(GameObject obj, bool highlight)
    {
        Outline outiline = obj.GetComponent<Outline>();
        if (outiline != null)
        {
            outiline.enabled = highlight;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        float raycasDistance = 1.0f;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, raycasDistance))
        {
            hittedObject = hit.transform.gameObject;
            if (hittedObject.CompareTag("bag"))
            {
                Debug.Log("bag");
                HighlightObject(hittedObject, true);
                btnE_bag.SetActive(true);
                canPickUpBag = true;
            }

            if (hittedObject.CompareTag("money"))
            {
                HighlightObject(hittedObject, true);
                btnE_money.SetActive(true);
                canPickUpMoney = true;
            }

            if (hittedObject.CompareTag("food"))
            {
                HighlightObject(hittedObject, true);
                btnE_food.SetActive(true);
                canPickUpFood = true;
            }
        }
        else
        {
            hittedObject = null;
            canPickUpBag = false;
            canPickUpFood = false;
            canPickUpMoney = false;

            btnE.SetActive(false);
            btnE_food.SetActive(false);
            btnE_money.SetActive(false);
            btnE_bag.SetActive(false);
        }

        if (previousHittedObject != hittedObject)
        {
            if (previousHittedObject != null)
            {
                HighlightObject(previousHittedObject, false);
            }
            previousHittedObject = hittedObject;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPickUpBag)
        {
            bag.SetActive(false);
            isPickUpBag = true;
            btnE.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.E) && canPickUpMoney)
        {
            money.SetActive(false);
            isPickUpMoney = true;
            btnE.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.E) && canPickUpFood)
        {
            food.SetActive(false);
            isPickUpFood = true;
            btnE.SetActive(false);
        }
    }

}
