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
            if (messageObject != null)
            {
                messageObject.SetActive(true);
                Invoke(nameof(HideMessage), 10f);
            }
        }
    }
    private void HideMessage()
    {
        if (messageObject != null)
        {
            messageObject.SetActive(false);
        }
    }

}