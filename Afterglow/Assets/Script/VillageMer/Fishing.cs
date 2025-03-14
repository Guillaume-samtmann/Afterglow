using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public CamRaycast camRaycast;
    public DriveBoat driveBoat;


    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;

    public bool zone1Fishing = false;
    public bool zone2Fishing = false;
    public bool zone3Fishing = false;

    public bool zone1IsComplect = false;
    public bool zone2IsComplect = false;
    public bool zone3IsComplect = false;
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
            }
            else if (zone2.name == "Zone2")
            {
                Debug.Log("Tu es dans la zone de peche 2");
                zone2Fishing = true;
            }
            else if(zone3.name == "Zone3")
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
            zone1.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F) && zone1Fishing)
        {
            Debug.Log("Tu as pecher 2 poisson");
            zone1IsComplect = true;

            if (zone1IsComplect)
            {
                zone1.SetActive(false);
                zone2.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && zone2Fishing)
        {
            Debug.Log("Tu as pecher 4 poisson");
            zone2IsComplect = true;

            if (zone2IsComplect)
            {
                zone2.SetActive(false);
                zone3.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && zone3Fishing)
        {
            Debug.Log("Tu as pecher 1 poisson");
            zone3IsComplect = true;

            if (zone3IsComplect)
            {
                zone3.SetActive(false);
            }
        }
    }
}
