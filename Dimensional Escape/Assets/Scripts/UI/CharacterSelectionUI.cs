using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionUI : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button quitBtn;
   


    private void Awake()
    {
        playBtn.onClick.AddListener(() =>
        {
            Debug.Log("Play button clicked!");
            Loader.Load(Loader.Scene.Levels);
            
        });
        quitBtn.onClick.AddListener(() =>
        {
            Debug.Log("Play button clicked!");
            Loader.Load(Loader.Scene.MainMenu);
            
        });
        
    }
}
