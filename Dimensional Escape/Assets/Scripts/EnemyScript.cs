using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public TextMeshPro warningText; // Drag a floating TMP UI object above the enemy
    public Transform player;

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange)
        {
            // Face the player
            Vector3 direction = player.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);

            // Rotate warning text to face camera
            if (warningText != null)
            {
                warningText.transform.LookAt(Camera.main.transform);
                warningText.transform.Rotate(0, 180, 0);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Combat started!");
                // Trigger combat here
                SceneManager.LoadScene("TurnBasedCombat");
            }
        }
    }

    public void SetPlayerInRange(bool inRange)
    {
        playerInRange = inRange;

        if (warningText != null)
        {
            warningText.gameObject.SetActive(inRange);
        }

        Debug.Log(inRange ? "Player entered enemy zone" : "Player left enemy zone");
    }
}