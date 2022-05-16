using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Animator animator;
    public Animator player;
    public GameObject pauseCanvas;
    public Text pauseText;

    public int keysRequired;

    public string sceneToLoad;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        KeyCollector keyCollector = collision.gameObject.GetComponent<KeyCollector>();
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        ChangeMusic changeMusic = GetComponent<ChangeMusic>();

        if (keyCollector != null)
        {
            if (keyCollector.ConsumeKey(keysRequired))
            {
                changeMusic.ChangePlay();

                if(sceneToLoad == "null")
                {
                    playerMovement.movementSpeed = 0f;

                    animator.SetBool("OnContact", true);
                    player.SetBool("Win", true);

                    pauseCanvas.SetActive(true);
                    pauseText.text = "You Win!";
                }
                else
                {
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
            else
            {
                Debug.Log("Faltan llaves");
            }
        }
    }
}
    