using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public Animator _animator;
    public GameObject btnE;
    private bool isPlayerInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayerInTrigger = true;
            btnE.SetActive(true);
        }
        else
        {
            btnE.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayerInTrigger = false;
            btnE.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInTrigger && Input.GetKeyUp(KeyCode.E))
        {
            if (!_animator.GetBool("canOpen"))
            {
                _animator.SetBool("canOpen", true);
                btnE.SetActive(false);
            }
            else
            {
                _animator.SetBool("canOpen", false);
            }
        }
        
    }
}
