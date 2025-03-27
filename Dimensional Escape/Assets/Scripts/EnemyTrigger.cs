using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject enemyObject; // Drag the enemy GameObject here

    private EnemyScript enemyScript;

    private void Start()
    {
        // Get the EnemyScript from the GameObject
        enemyScript = enemyObject.GetComponent<EnemyScript>();
        if (enemyScript == null)
        {
            Debug.LogError("❌ No EnemyScript found on the assigned enemy object.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && enemyScript != null)
        {
            enemyScript.SetPlayerInRange(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && enemyScript != null)
        {
            enemyScript.SetPlayerInRange(false);
        }
    }
}