using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStart : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    public GameObject btnE;
    bool conversationStart = false;
    public GameObject canneApeche;

    Fishing fishing;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            btnE.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)) {
                ConversationManager.Instance.StartConversation(myConversation);
                btnE.SetActive(false);
                conversationStart = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        btnE.SetActive(false);
        conversationStart=false;
    }

}
