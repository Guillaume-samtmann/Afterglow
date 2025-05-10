using UnityEngine;

public class TableTriggerDisplay : MonoBehaviour
{
    public GameObject messageObject;
    public GameObject btnF;
    private bool hasShownMessage = false;
    private bool isMessageVisible = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasShownMessage && other.gameObject.name == "table")
        {
            hasShownMessage = true;
            btnF.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hasShownMessage = false;
        btnF.SetActive(false);
    }

    private void HideMessage()
    {
        if (messageObject != null)
        {
            messageObject.SetActive(false);
            isMessageVisible = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && hasShownMessage)
        {
            if (messageObject != null)
            {
                if (!isMessageVisible)
                {
                    messageObject.SetActive(true);
                    isMessageVisible = true;
                    Invoke(nameof(HideMessage), 10f);
                }
                else
                {
                    CancelInvoke(nameof(HideMessage));
                    HideMessage();
                }
            }
            btnF.SetActive(false);
        }
    }
}
