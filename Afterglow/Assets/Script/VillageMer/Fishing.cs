using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    public CamRaycast camRaycast;
    public DriveBoat driveBoat;


    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;
    public GameObject persoCanePeche;
    public GameObject zoneDialog2;

    public bool zone1Fishing = false;
    public bool zone2Fishing = false;
    public bool zone3Fishing = false;

    public bool zone1IsComplect = false;
    public bool zone2IsComplect = false;
    public bool zone3IsComplect = false;

    public bool canAnnim = false;

    public int nbrPoisson = 0;

    public Text nbrPoissonAff;
    // Update is called once per frame
    void Update()
    {
        ZoneFishing();

        if(nbrPoisson >= 3)
        {
            zoneDialog2.SetActive(true);
        }
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
                canAnnim = true;
            }
            else if(other.name == "Zone3")
            {
                Debug.Log("Tu es dans la zone de peche 3");
                zone3Fishing = true;
                canAnnim = true;
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
            canAnnim = false;
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
            nbrPoissonAff.text = nbrPoisson.ToString();
            zone1IsComplect = true;
            if (zone1IsComplect)
            {
                zone1.SetActive(false);
                StartCoroutine(disableCanePeche());
                zone1Fishing = false;
                zone2.SetActive(true);
            }
        }else if (Input.GetKeyDown(KeyCode.F) && zone2Fishing)
        {
            persoCanePeche.SetActive(true);
            nbrPoisson = nbrPoisson + Random.Range(2, 4);
            nbrPoissonAff.text = nbrPoisson.ToString();
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
            nbrPoissonAff.text = nbrPoisson.ToString();
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
        yield return new WaitForSeconds(3);
        persoCanePeche.SetActive(false);
    }
}
