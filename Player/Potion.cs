using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public int healingPotency = 1;
    public AudioSource soundDrinking;
    private void Start()
    {
        if (soundDrinking == null)
        {
            soundDrinking = GameObject.FindGameObjectWithTag("PotionDrink").GetComponent<AudioSource>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();

            if (playerHealth != null)
            {
                if (playerHealth.ReceiveHealing(healingPotency) == true)
                {
                    soundDrinking.Play();

                    Destroy(this.gameObject);
                }
            }
        }
    }
}
