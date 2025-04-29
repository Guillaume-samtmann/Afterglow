using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour
{
    Animator anim;
    private NavMeshAgent agent;
    public bool joueurVu = false;

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
        }
    }
}
