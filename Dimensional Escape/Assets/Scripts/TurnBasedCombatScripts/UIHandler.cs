using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI enemyHealthText;
    public TextMeshProUGUI gameDisplayText;
    public TextMeshProUGUI playerControlsText;
    
    public void SetPlayerHealth(int value)
    {
        playerHealthText.text = "Player Health: " + value;
    }

    public void SetEnemyHealth(int value)
    {
        enemyHealthText.text = "Enemy Health: " + value;
    }

    public void SetGameDisplay(string message)
    {
        gameDisplayText.text = message;
    }

    public void SetControlsInfo()
    {
        playerControlsText.text = "Player Controls:\nH = Heal\nSpace Bar = Hit";
    }
    
}
