using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobMove : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject centre = GameObject.Find("Centre");
        target = centre.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        NavMeshPath path = new NavMeshPath();
        agent.destination = target.position;
    }

}
