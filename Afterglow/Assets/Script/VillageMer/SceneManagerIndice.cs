using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerIndice : MonoBehaviour
{
    public CamRaycast camRaycast;
    public Fishing fishing;
    public PickUpAxe pickUpAxe;
    public Mob mob;
    public DriveBoat driveBoat;

    public GameObject dialog1;
    public GameObject perle;
    public GameObject perso1Dialog1;
    public GameObject afterRock;
    public bool destroyAllRock = false;
    private bool canAfficehMsg = true;
    private bool canAfficheMsg2 = true;


    [Header("consignes")]
    public GameObject wanted;
    public GameObject poissonier;
    public GameObject pecher;
    public GameObject ramener;
    public GameObject casser;
    public GameObject tuer;
    public GameObject indice;
    public GameObject charpentier;

    private void Start()
    {
        wanted.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("AfterRock"))
        {
            destroyAllRock = true;
        }
    }

    void Update()
    {
        Missions();
        Perso1Dialog();
        Perso2Dialog();
        GoMontagne();
    }

    void Perso2Dialog()
    {
        if( camRaycast.isPickUpIndice1 )
        {
            dialog1.SetActive(true);
        }
    }

    void GoMontagne()
    {
        if (camRaycast.isPickupPerle)
        {
            SceneManager.LoadScene(4);
        }
    }

    void Perso1Dialog()
    {
        if (camRaycast.isPickupWanted0)
        {
            perso1Dialog1.SetActive(true);
            wanted.SetActive(false);
            poissonier.SetActive(true);
            camRaycast.isPickupWanted0 = false;
        }
    }

    void Missions()
    {
        if (camRaycast.canFishing)
        {
            poissonier.SetActive(false);
            wanted.SetActive(false);
            pecher.SetActive(true);
            camRaycast.canFishing = true;
        }
        if (driveBoat.aidePeche)
        {
            pecher.SetActive(false);
        }
        if(fishing.nbrPoisson >= 3 && canAfficehMsg)
        {
            pecher.SetActive(false);
            ramener.SetActive(true);
            canAfficehMsg = false;
        }
        if (camRaycast.piocheIsPickup)
        {
            casser.SetActive(true);
            camRaycast.canFishing = false;
            pecher.SetActive(false);
        }
        if (destroyAllRock)
        {
            casser.SetActive(false);
            tuer.SetActive(true);
            pecher.SetActive(false);
        }
        if(mob.isDead)
        {
            tuer.SetActive(false);
            indice.SetActive(true);
            ramener.SetActive(false);
            pecher.SetActive(false);
        }
        if (camRaycast.isPickUpIndice1)
        {
            indice.SetActive(false);
        }
        if (camRaycast.isPickUpIndice1 && canAfficheMsg2)
        {
            charpentier.SetActive(true);
            pecher.SetActive(false);
            canAfficheMsg2 = false;
        }

    }
}
