using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public GameObject btnE;
    private bool canLoad = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("loadSceneVillage"))
        {
            btnE.SetActive(true);
            canLoad = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("loadSceneVillage"))
        {
            btnE.SetActive(true);
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.E) && canLoad)
        {
            SceneManager.LoadScene(5);
        }
    }
}
