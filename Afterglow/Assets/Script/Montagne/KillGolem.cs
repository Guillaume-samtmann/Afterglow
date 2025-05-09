using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGolem : MonoBehaviour
{
    public GameObject golem1;
    public GameObject golem2;
    public GameObject BlocMap;
    public GameObject BlocMapMsg;
    public GameObject blocMapMsgTxt;


    private void Update()
    {
        if ((golem1 == null || !golem1.activeInHierarchy) &&
            (golem2 == null || !golem2.activeInHierarchy))
        {
            BlocMap.SetActive(false);
            BlocMapMsg.SetActive(false);
            blocMapMsgTxt.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlocMapMsg"))
        {
            blocMapMsgTxt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BlocMapMsg"))
        {
            blocMapMsgTxt.SetActive(false);
        }
    }
}
