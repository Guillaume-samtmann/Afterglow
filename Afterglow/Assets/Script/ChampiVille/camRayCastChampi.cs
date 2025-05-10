using System.Collections;
using System.Collections.Generic;
//using TreeEditor;
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
    public GameObject btnE_arc;

    [Header("Items")]
    public GameObject bag;
    public GameObject money;
    //public GameObject food;

    public GameObject carrot;
    public GameObject bottle;
    public GameObject potato;
    public GameObject loaf;
    public GameObject meat;

    public GameObject arc;


    public GameObject task1;
    public GameObject task2;
    public GameObject task3;

    public bool canPickUpBag = false;
    public bool canPickUpMoney = false;
    //public bool canPickUpFood = false;
    public bool canPickUpCarrot = false;
    public bool canPickUpBottle = false;
    public bool canPickUpPotato = false;
    public bool canPickUpLoaf = false;
    public bool canPickUpMeat = false;
    public bool canPickUpArc = false;

    public bool isPickUpBag = false;
    public bool isPickUpMoney = false;
    //public bool isPickUpFood = false;
    public bool isPickUpCarrot = false;
    public bool isPickUpBottle = false;
    public bool isPickUpPotato = false;
    public bool isPickUpLoaf = false;
    public bool isPickUpMeat = false;
    public bool isPickUpArc = false;
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
                if(hittedObject.name == "carrot (1)")
                {
                    HighlightObject(hittedObject, true);
                    btnE_food.SetActive(true);
                    canPickUpCarrot = true;
                }
                if (hittedObject.name == "wicker_bottle")
                {
                    HighlightObject(hittedObject, true);
                    btnE_food.SetActive(true);
                    canPickUpBottle = true;
                }
                if (hittedObject.name == "big_meat")
                {
                    HighlightObject(hittedObject, true);
                    btnE_food.SetActive(true);
                    canPickUpMeat = true;
                }
                if (hittedObject.name == "potato (3)")
                {
                    HighlightObject(hittedObject, true);
                    btnE_food.SetActive(true);
                    canPickUpPotato = true;
                }
                if (hittedObject.name == "long_loaf")
                {
                    HighlightObject(hittedObject, true);
                    btnE_food.SetActive(true);
                    canPickUpLoaf = true;
                }
            }
            if (hittedObject.CompareTag("arc"))
            {
                HighlightObject(hittedObject, true);
                btnE_arc.SetActive(true);
                canPickUpArc = true;
            }
        }
        else
        {
            hittedObject = null;
            canPickUpBag = false;
            //canPickUpFood = false;
            canPickUpCarrot = false;
            canPickUpMoney = false;
            canPickUpBottle =false;
            canPickUpMeat = false;
            canPickUpLoaf = false;

            btnE.SetActive(false);
            btnE_food.SetActive(false);
            btnE_money.SetActive(false);
            btnE_bag.SetActive(false);
            btnE_arc.SetActive(false);
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
            task1.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.E) && canPickUpMoney)
        {
            money.SetActive(false);
            isPickUpMoney = true;
            btnE.SetActive(false);
            task2.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.E) && canPickUpCarrot)
        {
            carrot.SetActive(false);
            isPickUpCarrot = true;
            btnE.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.E) && canPickUpBottle)
        {
            bottle.SetActive(false);
            isPickUpBottle = true;
            btnE.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.E) && canPickUpMeat)
        {
            meat.SetActive(false);
            isPickUpMeat = true;
        }
        if (Input.GetKeyUp(KeyCode.E) && canPickUpPotato)
        {
            potato.SetActive(false);
            isPickUpPotato = true;
        }
        if (Input.GetKeyUp(KeyCode.E) && canPickUpLoaf)
        {
            loaf.SetActive(false);
            isPickUpLoaf = true;
        }
        if(isPickUpCarrot && isPickUpBottle && isPickUpMeat && isPickUpPotato && isPickUpLoaf)
        {
            task3.SetActive(true);
        }
        if(Input.GetKey(KeyCode.E) && canPickUpArc)
        {
            arc.SetActive(false);
            isPickUpArc = true;
        }
    }

}
