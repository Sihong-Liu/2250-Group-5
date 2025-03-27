using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenuUi : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button quitBtn;


    private void Awake()
    {
        playBtn.onClick.AddListener(() =>
        {
            Debug.Log("Play button clicked!");
            Loader.Load(Loader.Scene.CharacterSelection);
            
        });
        quitBtn.onClick.AddListener(() =>
        {
            Debug.Log("Quitting game...");
            Application.Quit();
        });
    }
    
}
