using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionTriggeur : MonoBehaviour
{
    public Mob mob;
    public MobMove mobMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mob.joueurVu = true;
            mobMove.fin = true;
            Debug.Log("Detecter");
        }
    }
}
