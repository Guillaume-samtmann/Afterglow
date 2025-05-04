using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public Mob mob;
    private bool isAttacking = false;
    public PlayerManager playerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mob.attackPlayer = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mob.attackPlayer = false;
        }
    }


    public void TimeAttach()
    {
        StartCoroutine(timeAttackPlayer());
    }

    private void FixedUpdate()
    {
        if (mob.attackPlayer && !isAttacking)
        {
            TimeAttach();
        }
    }

    IEnumerator timeAttackPlayer()
    {
        isAttacking = true;
        yield return new WaitForSeconds(1.3f);
        playerManager.playerLife = playerManager.playerLife - 7;
        isAttacking = false;
    }
}
