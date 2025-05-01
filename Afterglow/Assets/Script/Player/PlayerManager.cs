using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerLife = 20;


    private void Update()
    {
        Debug.Log(playerLife);
        dead();
    }

    public void dead()
    {
        if(playerLife <= 0) {
            Debug.Log("perso mort");
        }
    }
}
