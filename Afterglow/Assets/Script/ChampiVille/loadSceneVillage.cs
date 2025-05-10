using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneVillage : MonoBehaviour
{
    public GameObject btnE;
    public bool canLoad = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("loadSceneVillage"))
        {
            btnE.SetActive(true);
            canLoad = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        btnE?.SetActive(false);
        canLoad=false;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && canLoad) 
        {
            SceneManager.LoadScene(1);
        }
    }
}
