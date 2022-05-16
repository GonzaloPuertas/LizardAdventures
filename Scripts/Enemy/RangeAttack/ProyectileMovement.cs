using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody.AddForce(transform.up * movementSpeed, ForceMode2D.Impulse);
    }
}
