using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public Animator _animator;
    public GameObject btnE_openDoor;
    public GameObject btnE_closeDoor;
    private bool isPlayerInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!_animator.GetBool("canOpen"))
            {
                isPlayerInTrigger = true;
                btnE_openDoor.SetActive(true);
            }else
            {
                isPlayerInTrigger = true;
                btnE_closeDoor.SetActive(true);
            }
               
        }
        else
        {
            btnE_openDoor.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayerInTrigger = false;
            btnE_openDoor.SetActive(false);
            btnE_closeDoor.SetActive(false);
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
                btnE_openDoor.SetActive(false);
            }
            else
            {
                _animator.SetBool("canOpen", false);
                btnE_closeDoor.SetActive(false);
            }
        }
        
    }
}
