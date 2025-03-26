
using UnityEngine;

public class HealthSystem
{
    private int health;

    public HealthSystem(int startingHealth)
    {
        health = startingHealth;
    }

    public void Damage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > 100) health = 100;
    }

    public int GetHealth()
    {
        return health;
    }

    public bool IsDead()
    {
        return health <= 0;
    }


}
