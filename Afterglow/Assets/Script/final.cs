using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
{
    public GameObject txt1;
    public GameObject afterGlow;
    public GameObject btn;
    void Start()
    {
        StartCoroutine(showTxt2());
    }

    IEnumerator showTxt2()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        yield return new WaitForSeconds(4);
        txt1.SetActive(false);
        afterGlow.SetActive(true);
        btn.SetActive(true);
    }


    public void replay()
    {
        SceneManager.LoadScene(0);
    }

}
