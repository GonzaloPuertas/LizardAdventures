using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public const string CURRENT_LEVEL_KEY = "CurrentLevel";
    public const string SPAWN_POSITION_X = "SpawnX";
    public const string SPAWN_POSITION_Y = "SpawnY";
    public const string PLAYER_HEALTH = "PlayerHealth";
    
    public Health playerHealth;

    string sceneName;
    
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == PlayerPrefs.GetString(CURRENT_LEVEL_KEY))
        {
            Vector2 spawnPosition;
            spawnPosition.x = PlayerPrefs.GetFloat(SPAWN_POSITION_X, transform.position.x);
            spawnPosition.y = PlayerPrefs.GetFloat(SPAWN_POSITION_Y, transform.position.y);

            transform.position = spawnPosition;
            playerHealth.SetHealthFromSave(PlayerPrefs.GetInt(PLAYER_HEALTH, playerHealth.currentHealth));
        }
        
        PlayerPrefs.SetString(CURRENT_LEVEL_KEY, sceneName);
    }

    public void CheckpointTriggered(Vector3 checkpointPosition)
    {
        PlayerPrefs.SetFloat(SPAWN_POSITION_X, checkpointPosition.x);
        PlayerPrefs.SetFloat(SPAWN_POSITION_Y, checkpointPosition.y);
        PlayerPrefs.SetInt(PLAYER_HEALTH, playerHealth.currentHealth);
    }
}