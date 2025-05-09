using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobMove : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    public static string nomObj;
    Animator anim;
    public bool fin = false;
    public GameObject centreD;
    public GameObject cache;

    private void Awake()
    {
        nomObj = centreD.name;
        agent = GetComponent<NavMeshAgent>();
        GameObject centre = GameObject.Find(nomObj);
        target = centre.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
        NavMeshPath path = new NavMeshPath();
        agent.destination = target.position;
    }

    private void Update()
    {
        float dist = agent.remainingDistance;
        if (agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance <= 0.5f)
        {
            anim.SetBool("isWalking", false);
            if (fin == false)
            {
                fin = true;
                setNewDestination(cache.name);
                StartCoroutine(GoCentre());
            }
        }
    }

    public void setNewDestination(string d)
    {
        nomObj = d;
        GameObject centre = GameObject.Find(nomObj);
        target = centre.transform;
        anim.SetBool("isWalking", true);
        NavMeshPath path = new NavMeshPath();
        agent.destination = target.position;
    }


    IEnumerator GoCentre()
    {
        yield return new WaitForSeconds(6);
        fin = false;
        setNewDestination(centreD.name);
    }
}
