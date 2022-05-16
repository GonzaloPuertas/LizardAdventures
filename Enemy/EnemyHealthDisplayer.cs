using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthDisplayer : MonoBehaviour
{
    public SpriteRenderer[] hearts;
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    void Start()
    {
        hearts = GetComponentsInChildren<SpriteRenderer>();
    }

    public void UpdateHealthValues(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeartSprite;
            }
            else
            {
                hearts[i].sprite = emptyHeartSprite;
            }
        }
    }
}
