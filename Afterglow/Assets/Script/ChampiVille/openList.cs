using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openList : MonoBehaviour
{
    public GameObject listObject;
    private bool isListVisible = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isListVisible)
        {
            Debug.Log("yep");
            listObject.SetActive(true);
            isListVisible = true;
        } else if (Input.GetKeyDown(KeyCode.R) && isListVisible)
        {
            Debug.Log("nop");
            listObject.SetActive(false);
            isListVisible = false;
        }
    }
}
