using Unity.VisualScripting;
using UnityEngine;

public class GameObjectUI : MonoBehaviour
{
      public CharacterDataBase characterDB;
    public Transform spawnPoint;
    
    private GameObject currentPlayer;
    
    void Start()
    {
        SpawnSelectedCharacter();
    }
    
    void SpawnSelectedCharacter()
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt("selectedOption", 0);
    
        // Get the character data from the database
        Character character = characterDB.GetCharacter(selectedCharacterIndex);
    
        // Instantiate the character prefab at the spawn point
        if (character.charcaterPrefab != null)
        {
            currentPlayer = Instantiate(character.charcaterPrefab, 
                spawnPoint.position, 
                spawnPoint.rotation);
        
            // Make sure the character has the necessary components
            SetupCharacterComponents(currentPlayer);
        
            // Set up the camera to follow this player
            SetupCamera(currentPlayer.transform);
        
            Debug.Log("Spawned character: " + character.charcaterName);
        }
        else
        {
            Debug.LogError("Character prefab is null for index: " + selectedCharacterIndex);
        }
    }

    void SetupCamera(Transform playerTransform)
    {
        // Find the CameraController in the scene
        CameraController cameraController = FindObjectOfType<CameraController>();
    
        if (cameraController != null)
        {
            // Add this field to your CameraController class:
            // public void SetPlayer(Transform playerTransform) { player = playerTransform; offsetDistanceY = transform.position.y; }
        
            // Call the new method
            cameraController.SetPlayer(playerTransform);
        }
        else
        {
            Debug.LogError("No CameraController found in the scene!");
        }
    }
    
    void SetupCharacterComponents(GameObject player)
    {
        // Make sure the player has the "Player" tag (required for CameraController)
        player.tag = "Player";
    
        // Set up CharacterBattle component
        CharacterBattle battle = player.GetComponent<CharacterBattle>();
        if (battle != null)
        {
            battle.Setup(true); // Set as player
        }

    }
}