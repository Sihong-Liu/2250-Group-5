using UnityEngine;

public class StoreTriggerDetector : MonoBehaviour
{
    public StoreScript storeScript; // Drag Store GameObject here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && storeScript != null)
        {
            storeScript.SetPlayerDetected(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && storeScript != null)
        {
            storeScript.SetPlayerDetected(false);
        }
    }
}