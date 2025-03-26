using System;
using UnityEngine;
using TMPro; // Correct import for TextMeshPro

public class NPCScripts : MonoBehaviour
{
    public TextMeshPro interactionText; // Assign in Inspector
    public Transform npcHead; // Assign NPC's Transform (or head position)
    public Transform player; // Assign Player's Transform
    bool playerDetected = false;

    void Update()
    {
        if (playerDetected)
        {
            // Make the NPC smoothly face the player
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0; // Keep NPC upright
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionToPlayer), Time.deltaTime * 5f);

            // Ensure the interaction text always faces the camera
            if (interactionText != null)
            {
                interactionText.transform.LookAt(Camera.main.transform);
                // Flip it back to fix mirrored issue
                interactionText.transform.Rotate(0, 180, 0);
            }

            // Check if the player presses F
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("✅ The dialogue has started");
            }
        }
    }

    public void SetPlayerDetected(bool detected)
    {
        playerDetected = detected;

        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(detected);
            interactionText.ForceMeshUpdate(); // Force update in case of rendering issues
        }

        Debug.Log(detected ? "✅ Player entered trigger zone" : "❌ Player left trigger zone");
    }
}