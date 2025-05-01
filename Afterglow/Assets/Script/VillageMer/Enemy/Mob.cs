using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour
{
    Animator anim;
    private NavMeshAgent agent;
    public bool joueurVu = false;
    public bool attackPlayer = false;
    public int enemyPtnVie = 15;

    public Arrow arrow;
    public MobMove mobMove;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.name == "DetectPlayer")
            {
                //agent.isStopped = true;
                //anim.SetBool("isWalking", false);
                //anim.SetBool("attack", true);
                //mobMove.setNewDestination("PlayerCapsule");
                mobMove.fin = true;
                joueurVu = true;
                Debug.Log("Detecter");
            }
            if (other.gameObject.name == "AttackPlayer")
            {
                Debug.Log("Tabassage");
            }
            
        }
     }*/

    private void Update()
    {
        if (joueurVu)
        {
            mobMove.setNewDestination("PlayerCapsule");
            transform.LookAt(GameObject.Find("PlayerCapsule").transform.position);
            Dead();
        }
        if (attackPlayer)
        {
            anim.SetBool("attack", true);
            anim.SetBool("isWalking", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            enemyPtnVie = enemyPtnVie - 5;
            anim.SetBool("isHurt", true);
            StartCoroutine(EnemyHurt());
            Debug.Log("Vie après coup : " + enemyPtnVie);
        }
    }

    void Dead()
    {
        if (enemyPtnVie <= 0)
        {
            anim.SetBool("attack", false);
            anim.SetBool("isDead", true);
            Destroy(gameObject, 5f);
        }
    }

    IEnumerator EnemyHurt()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("isHurt", false);
        anim.SetBool("attack", true);
    }
}
