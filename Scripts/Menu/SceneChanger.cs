using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void LoadLevelFromSave(string sceneToLoad)
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

        sceneToLoad = PlayerPrefs.GetString(SaveData.CURRENT_LEVEL_KEY, sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadLevel(string sceneToLoad)
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ReloadScene()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

        SceneManager.LoadScene("Game");
    }
}