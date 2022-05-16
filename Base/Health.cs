using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject objectDrop;

    public float immunityTime;
    public int immunityDuration;
    public bool isImmune;

    public Animator animator;
    public AudioSource hitSound;
    public AudioSource deadSound;

    public GameObject hitEffectPrefab;

    public PlayerHealthDisplayer healthDisplayer;
    public GameObject pauseCanvas;
    public Text pauseText;

    public PlayerMovement playerMovement;

    public EnemyHealthDisplayer enemyDisplayer;


    void Update()
    {
        if (isImmune == true)
        {
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                isImmune = false;
            }
        }
    }

    public void SetHealthFromSave(int newCurrentHealth)
    {
        currentHealth = newCurrentHealth;

        if (healthDisplayer != null)
        {
            healthDisplayer.UpdateHealthValues(currentHealth);
        }
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void ReceiveAttack(int damageAmount)
    {
        if (damageAmount > 0 && currentHealth > 0 && isImmune == false)
        {
            currentHealth -= damageAmount;
            hitSound.Play();

            if (healthDisplayer != null)
            {
                healthDisplayer.UpdateHealthValues(currentHealth);
            }

            if (enemyDisplayer != null)
            {
                enemyDisplayer.UpdateHealthValues(currentHealth);
            }

            isImmune = true;
            immunityTime = 0;

            animator.SetBool("IsHit", true);
        } 

        if (currentHealth <= 0)
        {
            if(pauseCanvas != null)
            {
                ChangeMusic changeMusic = GetComponent<ChangeMusic>();
                changeMusic.ChangePlay();

                pauseCanvas.SetActive(true);
                pauseText.text = "Game Over";
                playerMovement.movementSpeed = 0;
            }

            if(objectDrop != null)
            {
                Instantiate(objectDrop, transform.position, Quaternion.identity);
            }

            if(animator != null)
            {
                deadSound.Play();
                animator.SetBool("IsDead", true);
                
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if(hitEffectPrefab != null)
            {
                Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    public bool ReceiveHealing(int amount)
    {
        if(currentHealth > 0 && amount > 0 && currentHealth < maxHealth)
        {
            currentHealth += amount;

            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            if (healthDisplayer != null)
            {
                healthDisplayer.UpdateHealthValues(currentHealth);
            }

            return true;
        }
        else
        {
            return false;
        }
    }
    public void DestroyFromAnimation()
    {
        Destroy(this.gameObject);
    }
}
