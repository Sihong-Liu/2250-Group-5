using UnityEngine;


public class CharacterBattle : MonoBehaviour
{
    private bool isPlayer;
    private HealthSystem healthSystem;
    
    
    public void Setup(bool isPlayer)
    {
        this.isPlayer = isPlayer;
        healthSystem = new HealthSystem(100);
    }

    public void Attack(CharacterBattle targetCharacterBattle)
    {

        
        targetCharacterBattle.TakeDamage(20);

    }
    
    public void Heal()
    {
        if (isPlayer)
        {
            Debug.Log("Player heals!");
            healthSystem.Heal(20);
            Debug.Log("Player HP: " + healthSystem.GetHealth());
        }
    }
    
    public void TakeDamage(int amount)
    {
        healthSystem.Damage(amount);
        
    }
    
    public bool IsDead()
    {
        return healthSystem.IsDead();
    }

    public int GetHealth()
    {
        return healthSystem.GetHealth();
    }
    
    
    
    
    
}
