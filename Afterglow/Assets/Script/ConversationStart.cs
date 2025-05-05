using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using StarterAssets;

public class ConversationStart : MonoBehaviour
{
    public GameObject triggeurDialog1;
    public GameObject triggeurDialog2;
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private FirstPersonController firstPersonController;
    public GameObject btnE_poissonier;
    bool conversationStart = false;
    public GameObject canneApeche;

    Fishing fishing;

    private void OnTriggerEnter(Collider other)
    {
        conversationStart = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && conversationStart)
        {
            btnE_poissonier.SetActive(true);
        }
        if (ConversationManager.Instance.conversationEnd)
        {
            firstPersonController.enabled = true;
            triggeurDialog1.SetActive(false);
            triggeurDialog2.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        btnE_poissonier.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && conversationStart)
        {
            ConversationManager.Instance.StartConversation(myConversation);
            firstPersonController.enabled = false;
            btnE_poissonier.SetActive(false);
            conversationStart = false;
        }
    }

}
