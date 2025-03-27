using System;
using UnityEngine;
using TMPro; // Correct import for TextMeshPro

public class NPCScripts : MonoBehaviour
{
    public TextMeshPro interactionText; // Assign in Inspector
    public Transform npcHead; // Assign NPC's Transform (or head position)
    public Transform player; // Assign Player's Transform

    private bool playerDetected = false;
    private int currentDialogueIndex = 0;

    private string[] dialogueLines = new string[]
    {
        "Welcome to Dimensional Escape",
        "You are trapped in the matrix of the game AI, you have to escape",
        "Win battles, collect gems, and do quests to earn points",
        "You need 100 points to move on to the next level"
    };

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
                interactionText.transform.Rotate(0, 180, 0); // Fix mirrored issue
            }

            // Check if the player presses F
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (currentDialogueIndex < dialogueLines.Length)
                {
                    interactionText.text = dialogueLines[currentDialogueIndex];
                    currentDialogueIndex++;
                }
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

        if (!detected)
        {
            currentDialogueIndex = 0; // Reset dialogue if player leaves
        }

        Debug.Log(detected ? "✅ Player entered trigger zone" : "❌ Player left trigger zone");
    }
}
