using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int keysAwarded = 1;
    public AudioSource soundPickUp;

    private void Start()
    {
        if (soundPickUp == null)
        {
            soundPickUp = GameObject.FindGameObjectWithTag("PickUpSound").GetComponent<AudioSource>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        KeyCollector keyCollector = collision.GetComponent<KeyCollector>();

        if (keyCollector != null)
        {
            keyCollector.CollectKey(keysAwarded);

            soundPickUp.Play();

            Destroy(this.gameObject);
        }   
    }
}
