using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreValue = 10; //gem's score value

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // using the ScoreManager.cs
            ScoreManager.Instance.AddScore(scoreValue);

            // we can add reaction/text/soundfx here after collecting the gem

            // Delete the obj in the map
            Destroy(gameObject);
        }
    }
}
