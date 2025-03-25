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
            Loader.Load(Loader.Scene.Levels);
            
        });
        quitBtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
