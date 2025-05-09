using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using StarterAssets;

public class ConversationStartDial1Perso2 : MonoBehaviour
{
    public GameObject triggeurDialog1;
    public bool conversation2End = false;
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private FirstPersonController firstPersonController;
    public GameObject btnE_charpentier;
    bool conversationStart = false;

    Fishing fishing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            conversationStart = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && conversationStart)
        {
            btnE_charpentier.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        btnE_charpentier.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && conversationStart && !conversation2End)
        {
            ConversationManager.Instance.StartConversation(myConversation);
            firstPersonController.enabled = false;
            btnE_charpentier.SetActive(false);
            conversationStart = false;
            conversation2End = true;
        }
        if (ConversationManager.Instance.conversationEnd && conversation2End)
        {
            firstPersonController.enabled = true;
            triggeurDialog1.SetActive(false);
            btnE_charpentier.SetActive(false);
            StartCoroutine(enableScript());
        }
    }


    IEnumerator enableScript()
    {
        yield return new WaitForSeconds(1);
        this.enabled = false;
    }
}
