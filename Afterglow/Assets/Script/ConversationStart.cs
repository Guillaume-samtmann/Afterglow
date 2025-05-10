using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using StarterAssets;

public class ConversationStart : MonoBehaviour
{
    public GameObject triggeurDialog1;
    public bool conversation1End = false;
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private FirstPersonController firstPersonController;
    public GameObject btnE_poissonier;
    bool conversationStart = false;
    public GameObject canneApeche;

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
        if (Input.GetKeyDown(KeyCode.E) && conversationStart && !conversation1End)
        {
            ConversationManager.Instance.StartConversation(myConversation);
            firstPersonController.enabled = false;
            btnE_poissonier.SetActive(false);
            conversationStart = false;
            conversation1End = true;
            ConversationManager.Instance.TurnOnUI();

            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }

        if (ConversationManager.Instance.conversationEnd && conversation1End)
        {
            firstPersonController.enabled = true;
            triggeurDialog1.SetActive(false);

            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }

    }

}
