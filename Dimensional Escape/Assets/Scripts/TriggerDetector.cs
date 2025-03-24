using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public NPCScripts npcScript; // Assign Capsule (NPC) here in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && npcScript != null)
        {
            npcScript.SetPlayerDetected(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && npcScript != null)
        {
            npcScript.SetPlayerDetected(false);
        }
    }
}