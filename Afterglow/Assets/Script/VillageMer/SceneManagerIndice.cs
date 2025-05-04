using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerIndice : MonoBehaviour
{
    public CamRaycast camRaycast;
    public GameObject dialog1;

    public GameObject perle;

    void Update()
    {
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
            SceneManager.LoadScene(2);
        }
    }
}
