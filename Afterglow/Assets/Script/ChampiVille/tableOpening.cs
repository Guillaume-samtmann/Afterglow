using UnityEngine;
using UnityEngine.UI;

public class TableTriggerDisplay : MonoBehaviour
{
    public GameObject messageObject;
    public Text messageText;

    private bool isInTrigger = false;
    private bool hasShownMessage = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "table" && !hasShownMessage)
        {
            isInTrigger = true;
            messageText.text = "Appuyer sur E pour découvrir la première mission.";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "table")
        {
            isInTrigger = false;
            messageText.text = "";
        }
    }

    private void Update()
    {
        if (isInTrigger && !hasShownMessage && Input.GetKeyDown(KeyCode.E))
        {
            messageText.text = "";
            messageObject.SetActive(true);
            hasShownMessage = true;
        }
        else if (hasShownMessage && Input.GetKeyDown(KeyCode.E))
        {
            messageObject.SetActive(false);
        }
    }
}
