using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using StarterAssets;

public class ConversationStartDial2 : MonoBehaviour
{
    public GameObject triggeurDialog2;
    public bool conversation2End = false;
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private FirstPersonController firstPersonController;
    public GameObject btnE_poissonier;
    bool conversationStart = false;
    public GameObject canneApeche;
    //private bool conversationHandled = false;

    Fishing fishing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            conversationStart = true;
            Debug.Log(conversationStart);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && conversationStart)
        {
            btnE_poissonier.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        btnE_poissonier.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && conversationStart && !conversation2End)
        {
            ConversationManager.Instance.StartConversation(myConversation);
            firstPersonController.enabled = false;
            btnE_poissonier.SetActive(false);
            conversationStart = false;
            conversation2End = true;
        }
        if (ConversationManager.Instance.conversationEnd && conversation2End)
        {
            firstPersonController.enabled = true;
            triggeurDialog2.SetActive(false);
            btnE_poissonier.SetActive(false);
            //conversationHandled = true;
            StartCoroutine(enableScript());
        }
    }


    IEnumerator enableScript()
    {
        yield return new WaitForSeconds(1);
        this.enabled = false;
    }
}
