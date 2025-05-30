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
    public GameObject zoneDialog1;
    public GameObject zoneDialog2;

    public bool zone1Fishing = false;
    public bool zone2Fishing = false;
    public bool zone3Fishing = false;

    public bool zone1IsComplect = false;
    public bool zone2IsComplect = false;
    public bool zone3IsComplect = false;

    public bool canAnnim = false;
    public int nbrPoisson = 0;
    public GameObject btnPecher;

    public Text nbrPoissonAff;
    public GameObject arc;
    // Update is called once per frame
    void Update()
    {
        ZoneFishing();

        if(nbrPoisson >= 3)
        {
            zoneDialog2.SetActive(true);
            zoneDialog1.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ZoneFishing"))
        {
            if(other.name == "Zone1")
            {
                zone1Fishing = true;
                canAnnim = true;
                btnPecher.SetActive(true);
            }
            else if (other.name == "Zone2")
            {
                zone2Fishing = true;
                canAnnim = true;
                btnPecher.SetActive(true);
            }
            else if(other.name == "Zone3")
            {
                zone3Fishing = true;
                canAnnim = true;
                btnPecher.SetActive(true);
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
        btnPecher.SetActive(false);
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
            btnPecher.SetActive(false);
            nbrPoisson =  Random.Range(1, 4);
            nbrPoissonAff.text = nbrPoisson.ToString();
            zone1IsComplect = true;
            arc.SetActive(false);
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
            btnPecher.SetActive(false);
            arc.SetActive(false);
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
            btnPecher.SetActive(false);
            arc.SetActive(false);
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
