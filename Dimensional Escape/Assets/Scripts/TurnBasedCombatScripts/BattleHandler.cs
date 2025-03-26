using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    
    [SerializeField] private Transform capsulePrefab;

    private GameObject playerUnit;
    private GameObject enemyUnit;

    private enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSE }
    private BattleState state;

    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        // Instantiate player and enemy capsules
        playerUnit = Instantiate(capsulePrefab, new Vector3(-2, 0, 0), Quaternion.identity).gameObject;
        enemyUnit = Instantiate(capsulePrefab, new Vector3(2, 0, 0), Quaternion.identity).gameObject;

        // Name them for clarity
        playerUnit.name = "Player";
        enemyUnit.name = "Enemy";

        Debug.Log("Battle Started");
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        Debug.Log("Player's Turn");
        // In the next step, we’ll add UI here
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN) return;

        Debug.Log("Player attacks!");
        // Apply fake damage or animation later

        state = BattleState.ENEMYTURN;
        Invoke(nameof(EnemyTurn), 2f);
    }

    void EnemyTurn()
    {
        Debug.Log("Enemy attacks!");
        // Apply fake damage or animation later

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
}
