using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Histoire : MonoBehaviour
{
    public GameObject texet1;
    public GameObject texet2;
    public GameObject btn1;
    public GameObject btn2;

    public void switch1()
    {
        texet1.SetActive(false);
        texet2.SetActive(true);
        btn1.SetActive(false);
        btn2.SetActive(true);
    }

    public void switch2()
    {
        SceneManager.LoadScene(2);
    }
}
