using UnityEngine;

public class TableTriggerDisplay : MonoBehaviour
{
    public GameObject messageObject;
    private bool hasShownMessage = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasShownMessage && other.gameObject.name == "table")
        {
            hasShownMessage = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hasShownMessage = false;
    }
    private void HideMessage()
    {
        if (messageObject != null)
        {
            messageObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && hasShownMessage){
            if (messageObject != null)
            {
                messageObject.SetActive(true);
                Invoke(nameof(HideMessage), 10f);
            }
        }
    }

}