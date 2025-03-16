using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public CamRaycast camRaycast;
    public DriveBoat driveBoat;


    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;
    public GameObject persoCanePeche;

    public bool zone1Fishing = false;
    public bool zone2Fishing = false;
    public bool zone3Fishing = false;

    public bool zone1IsComplect = false;
    public bool zone2IsComplect = false;
    public bool zone3IsComplect = false;

    public bool canAnnim = false;

    int nbrPoisson = 0;
    // Update is called once per frame
    void Update()
    {
        ZoneFishing();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ZoneFishing"))
        {
            if(other.name == "Zone1")
            {
                Debug.Log("Tu es dans la zone de peche 1");
                zone1Fishing = true;
                canAnnim = true;
            }
            else if (other.name == "Zone2")
            {
                Debug.Log("Tu es dans la zone de peche 2");
                zone2Fishing = true;
            }
            else if(other.name == "Zone3")
            {
                Debug.Log("Tu es dans la zone de peche 3");
                zone3Fishing = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ZoneFishing"))
        {
            zone1Fishing = false;
            zone2Fishing =false;
            zone3Fishing =false;
        }
    }

    void ZoneFishing()
    {
        if (camRaycast.canFishing && driveBoat.isDriving)
        {
            if (zone1IsComplect)
            {
                zone1.SetActive(false);
            }
            else
            {
                zone1.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && zone1Fishing)
        {
            persoCanePeche.SetActive(true);
            nbrPoisson =  Random.Range(1, 4);
            Debug.Log("nbr poisson zone1 " + nbrPoisson);
            zone1IsComplect = true;
            if (zone1IsComplect)
            {
                zone1.SetActive(false);
                //StartCoroutine(disableCanePeche());
                zone1Fishing = false;
                zone2.SetActive(true);
            }
        }else if (Input.GetKeyDown(KeyCode.F) && zone2Fishing)
        {
            persoCanePeche.SetActive(true);
            nbrPoisson = nbrPoisson + Random.Range(2, 4);
            Debug.Log("nbr poisson zone2 " + nbrPoisson);
            zone2IsComplect = true;
            if (zone2IsComplect)
            {
                zone2.SetActive(false);
                StartCoroutine(disableCanePeche());
                zone2Fishing = false;
                zone3.SetActive(true);
            }
        }else if (Input.GetKeyDown(KeyCode.F) && zone3Fishing)
        {
            persoCanePeche.SetActive(true);
            nbrPoisson = nbrPoisson + Random.Range(1, 3);
            Debug.Log("nbr poisson zone3 " + nbrPoisson);
            zone3IsComplect = true;
            if (zone3IsComplect)
            {
                zone3.SetActive(false);
                StartCoroutine(disableCanePeche());
                zone3Fishing = false;
            }
        }
    }

    IEnumerator disableCanePeche()
    {
        yield return new WaitForSeconds(2);
        persoCanePeche.SetActive(false);
    }
}
