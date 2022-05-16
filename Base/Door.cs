using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int keysRequired;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        KeyCollector keyCollector = collision.gameObject.GetComponent<KeyCollector>();

        if (keyCollector != null)
        {
            if (keyCollector.ConsumeKey(keysRequired))
            {
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Faltan llaves");
            }
        }
    }
}
