using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    public void LoadingMainMenu()
    {   
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}