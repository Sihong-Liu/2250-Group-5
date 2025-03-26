using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button quitBtn;
    [SerializeField] private Button menuBtn;
    [SerializeField] private GameObject pauseMenu;


    private void awake()
    {
        resumeBtn.onClick.AddListener(() =>
        {
            Debug.Log("resume btn clicked");
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            
        });
        quitBtn.onClick.AddListener((() =>
        {
            Debug.Log("quit btn clicked");
            Application.Quit();
        }));
        menuBtn.onClick.AddListener(() =>
        {
            Debug.Log("menu btn clicked");
            
        });
    }


}
