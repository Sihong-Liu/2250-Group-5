using UnityEngine;

public class ScoreWallDisabler : MonoBehaviour
{
    public GameObject wallObject; // Wall to disable
    public int scoreThreshold = 100; // Score needed to disable it
    private bool wallDisabled = false;

    void Update()
    {
        if (!wallDisabled && ScoreManager.Instance.currentScore >= scoreThreshold)
        {
            wallObject.SetActive(false);
            wallDisabled = true;
        }
    }
}