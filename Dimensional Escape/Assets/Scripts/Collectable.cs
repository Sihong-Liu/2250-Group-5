using UnityEngine;

public class Collectable : MonoBehaviour//this monobehaviour script works as a component of Gem or other collectables in map.
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
