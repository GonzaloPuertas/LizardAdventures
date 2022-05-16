using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offsetL;
    public Vector3 offsetR;

    void Update()
    {
        Vector2 inputVector;
        inputVector.x = Input.GetAxis("Horizontal");

        if (inputVector.x > 0)
        {
            transform.position = target.position + offsetL;
        }
        else if (inputVector.x < 0)
        {
            transform.position = target.position + offsetR;
        }
    }
}