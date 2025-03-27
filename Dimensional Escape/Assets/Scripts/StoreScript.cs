using UnityEngine;
using TMPro;

public class StoreScript : MonoBehaviour
{
    public TextMeshPro interactionText;
    public Transform player;

    private bool playerDetected = false;

    void Update()
    {
        if (playerDetected)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("🛒 Store entered");
                // You can load a store UI here
            }
        }
    }

    public void SetPlayerDetected(bool detected)
    {
        playerDetected = detected;

        if (interactionText != null)
        {
            interactionText.text = "Press F to enter store";
            interactionText.gameObject.SetActive(detected);
            interactionText.ForceMeshUpdate();
        }

        Debug.Log(detected ? "🟢 Player at store" : "🔴 Player left store");
    }
}