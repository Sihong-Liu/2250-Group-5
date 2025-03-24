using System;
using UnityEngine;
using UnityEngine.UI; // For UI elements (optional)

public class NPCScripts : MonoBehaviour
{
    bool playerDetected = false;
    public GameObject interactionUI; // Assign a UI Text object in the Inspector

    void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("✅ The dialogue has started");
        }
    }

    // This function will be called by the child (Sphere) trigger
    public void SetPlayerDetected(bool detected)
    {
        playerDetected = detected;

        if (interactionUI != null)
        {
            interactionUI.SetActive(detected); // Show or hide the "Press F to interact" UI
        }

        if (detected)
        {
            Debug.Log("✅ Player entered trigger zone");
        }
        else
        {
            Debug.Log("❌ Player left trigger zone");
        }
    }
}