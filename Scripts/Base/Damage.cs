using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    public bool doesCollisionDamage;
    public bool doesTriggerDamage;

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (doesCollisionDamage)
        {
            Health hitHealth = collision.collider.GetComponent<Health>();

            if (hitHealth != null)
            {
                hitHealth.ReceiveAttack(damage);
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D otherCollider)
    {
        if (doesTriggerDamage)
        {
            Health hitHealth = otherCollider.GetComponent<Health>();

            if (hitHealth != null)
            {
                hitHealth.ReceiveAttack(damage);
            }
        }
    }
}