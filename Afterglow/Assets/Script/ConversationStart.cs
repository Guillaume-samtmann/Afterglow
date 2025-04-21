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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            btnE.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)) {
                ConversationManager.Instance.StartConversation(myConversation);
                btnE.SetActive(false);
                conversationStart = true;

                if(conversationStart)
                {
                     int giveCanne = ConversationManager.Instance.GetInt("teste");
                    Debug.Log(giveCanne);
                    if (giveCanne == 1)
                    {
                        Debug.Log("voici le chiffre 1");
                        canneApeche.SetActive(true);
                    }
                }

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        btnE.SetActive(false);
        conversationStart=false;
    }

}
