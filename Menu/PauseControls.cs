using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControls : MonoBehaviour
{
    public KeyCode pauseKey = KeyCode.Escape;
    bool isPaused;
    public GameObject pauseCanvas;
    public Health Health;
    public PlayerMovement playerMovement;

    void Update()
    {
        if (Input.GetKeyDown(pauseKey) == true && (Health.currentHealth > 0 && playerMovement.movementSpeed > 0))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if(isPaused == true)
        {
            Time.timeScale = 0f;
            pauseCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseCanvas.SetActive(false);
        }
    }
}
