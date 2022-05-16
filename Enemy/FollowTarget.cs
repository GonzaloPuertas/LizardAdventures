using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float movementSpeed;
    public Vector3 distanceToTarget;
    public Rigidbody2D myRigidbody;
    public Animator animator;

    private void Awake()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Health health = GetComponent<Health>();

        if (health.currentHealth > 0)
        {
            distanceToTarget = target.position - transform.position;
            distanceToTarget.Normalize();
            //transform.right = distanceToTarget;
            //transform.position += distanceToTarget * movementSpeed * Time.deltaTime; 
            myRigidbody.MovePosition(myRigidbody.position + (Vector2)distanceToTarget * movementSpeed * Time.deltaTime);

            animator.SetBool("IsWalking", true);

            if (this.transform.position.x < target.transform.position.x) //Llendo a la derecha
            {
                animator.SetBool("GoingLeft", false);
            }
            else if (this.transform.position.x > target.transform.position.x) //Llendo a la izquierda
            {
                animator.SetBool("GoingLeft", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}