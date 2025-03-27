/*
 !!!README!!!
 To use this manager in other script when you want to add score, Simply add "ScoreManager.Instance.AddScore(x)" in that script, score will be added;
"x" is the score you would want that event add.
 */
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int currentScore = 0;
    public TextMeshProUGUI scoreText; //@Manas, Assign this in the UI(Canvas) you might want to use this variable, or change it's name to what every you were using.

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);// this is to delete extra instance.
        }
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        Invoke(nameof(UpdateScoreUI), 0.5f);
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()//here is when score shows on screen, edit it as you need.
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Re-assign the scoreText by finding it in the new scene
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        UpdateScoreUI(); // Refresh UI
    }
    
}
