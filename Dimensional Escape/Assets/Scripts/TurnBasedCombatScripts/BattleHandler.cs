using UnityEngine;


public class BattleHandler : MonoBehaviour
{
    
    [SerializeField] private Transform capsulePrefab;
    [SerializeField] private UIHandler uiHandler;

    //Instances of battle class
    private CharacterBattle playerCharacterBattle;
    private CharacterBattle enemyCharacterBattle;
    
    private State state;


    //States of turn based combat
    private enum State
    {
        WaitingForPlayer,
        Busy,
        BattleOver
    }
    
    

    private void Start()
    {
       
        //spawn in method for enemy and player
        playerCharacterBattle = SpawnCharacter(true);
        enemyCharacterBattle = SpawnCharacter(false);
        
        //Player goes first
        state = State.WaitingForPlayer;
        
        uiHandler.SetPlayerHealth(playerCharacterBattle.GetHealth());
        uiHandler.SetEnemyHealth(enemyCharacterBattle.GetHealth());
        uiHandler.SetGameDisplay("Player Turn");
        uiHandler.SetControlsInfo();
        
        
    }

    //Spawns in the player character and the enemy
    //Player on left
    private CharacterBattle SpawnCharacter(bool isPlayer)
    {
        Vector3 position;

        if (isPlayer)
        {
            position = new Vector3(425f, 10f, 100f);
        }
        else
        {
            position = new Vector3(575f, 10f, 100f);
        }

        Transform characterTransform = Instantiate(capsulePrefab, position, Quaternion.identity);
        CharacterBattle characterBattle = characterTransform.gameObject.AddComponent<CharacterBattle>();
        characterBattle.Setup(isPlayer);
        return characterBattle;
    }

    private void Update()
    {
        if (state != State.WaitingForPlayer) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = State.Busy;
            playerCharacterBattle.Attack(enemyCharacterBattle);
            uiHandler.SetEnemyHealth(enemyCharacterBattle.GetHealth());

            if (enemyCharacterBattle.IsDead())
            {
                uiHandler.SetGameDisplay("You Win!");
                state = State.BattleOver;
                return;
            }


            uiHandler.SetGameDisplay("Enemy Turn");
            Invoke(nameof(EnemyTurn), 1f);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            state = State.Busy;
            playerCharacterBattle.Heal();
            uiHandler.SetPlayerHealth(playerCharacterBattle.GetHealth());

            uiHandler.SetGameDisplay("Enemy Turn");
            Invoke(nameof(EnemyTurn), 1f);
        }
    }
    
    private void EnemyTurn()
    {
        
        enemyCharacterBattle.Attack(playerCharacterBattle);
        uiHandler.SetPlayerHealth(playerCharacterBattle.GetHealth());

        if (playerCharacterBattle.IsDead())
        {
            uiHandler.SetGameDisplay("You Lose!");
            state = State.BattleOver;
            return;
        }

        uiHandler.SetGameDisplay("Player Turn");
        state = State.WaitingForPlayer;
    }
    
    
    
    
}
