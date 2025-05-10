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
    //public GameObject centreD;
    public GameObject cache;

    [SerializeField] private GameObject centreD; // Assigne ceci dans l'Inspector;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        if (centreD != null)
        {
            target = centreD.transform;
        }
        else
        {
            Debug.LogError("centreD n'est pas assigné dans l'inspector pour " + gameObject.name);
        }
    }

    private IEnumerator Start()
    {
        anim = GetComponent<Animator>();
        if (anim != null)
            anim.SetBool("isWalking", true);

        yield return null; // Attend que la frame initiale se termine

        if (target != null)
            agent.destination = target.position;
        else
            Debug.LogError("La cible (target) est NULL pour " + gameObject.name);
    }

    /*private void Start()
    {
        anim = GetComponent<Animator>();

        if (anim != null)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            Debug.LogWarning("Aucun Animator trouvé sur " + gameObject.name);
        }

        if (target != null)
        {
            agent.destination = target.position;
        }
        else
        {
            Debug.LogError("La cible (target) est NULL pour " + gameObject.name);
        }
    }*/

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
