using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAxe : MonoBehaviour
{
    bool canTakeAxe = false;
    public GameObject Axe;
    public GameObject btnE;
    public bool AxeIsTake = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            btnE.SetActive(true);
            canTakeAxe = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        btnE.SetActive(false);
        canTakeAxe=false;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && canTakeAxe) {
            Axe.SetActive(false);
            btnE.SetActive(false);
            AxeIsTake = true;
        }
    }
}
