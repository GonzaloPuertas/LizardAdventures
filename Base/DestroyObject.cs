using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public bool onTriggerDestroy;
    public bool onCollisionDestroy;
    public bool onTimeDestroy;

    public float timeBeforeDestroying;

    void Start()
    {
        if (onTimeDestroy)
        {
            Destroy(this.gameObject, timeBeforeDestroying);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            Destroy(this.gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            Destroy(this.gameObject);
        
    }
}