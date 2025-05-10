using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Demarrage : MonoBehaviour
{
    public GameObject panel1;
    public GameObject option;
    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void showOption()
    {
        panel1.SetActive(false);
        option.SetActive(true);
    }

    public void back()
    {
        panel1.SetActive(true);
        option.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
