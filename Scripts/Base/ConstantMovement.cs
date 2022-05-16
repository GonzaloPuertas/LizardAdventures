using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRigidbody;

    void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + (Vector2)transform.right * speed * Time.deltaTime);
    }
}
