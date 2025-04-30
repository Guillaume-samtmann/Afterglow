using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour
{
    Animator anim;
    private NavMeshAgent agent;
    public bool joueurVu = false;
    public int enemyPtnVie = 15;

    public Arrow arrow;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            agent.isStopped = true;
            anim.SetBool("isWalking", false);
            anim.SetBool("attack", true);
            joueurVu = true;
        }
    }

    private void Update()
    {
        if (joueurVu)
        {
            transform.LookAt(GameObject.Find("PlayerCapsule").transform.position);
            Dead();
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
