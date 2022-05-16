using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D myRigidbody;
    public Animator animator;
    public Vector2 inputVector;
    
    public Transform cameraToFollow;
    public Transform cameraToFollow2;
    public Vector3 offsetCamera;

    public AudioSource attackSound;

    public float coldownAttack = 1;

    public float nextAttack;
    public bool mele = true;

    public GameObject sword;
    public GameObject bow;

    void Update()
    {
        cameraToFollow.position = transform.position + offsetCamera;
        cameraToFollow2.position = transform.position + offsetCamera;

        Movement();
        Attack();
        ChangeWeapon();
    }

    private void Attack()
    {
        if (sword != null)
        {
            if (Input.GetMouseButtonDown(0) && Time.time > nextAttack)
            {
                if (mele == true)
                {
                    animator.SetBool("Attack", true);
                }
                else if (mele == false)
                {
                    animator.SetBool("AttackBow", true);
                }

                attackSound.Play();
                nextAttack = Time.time + coldownAttack;
            }
        }
        else if (bow != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (mele == true)
                {
                    animator.SetBool("Attack", false);
                }
                else if (mele == false)
                {
                    animator.SetBool("AttackBow", false);
                }
            }
        }
    }

    private void Movement()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        animator.SetFloat("HorizontalInput", inputVector.x);
        animator.SetFloat("VerticalInput", inputVector.y);

        if (inputVector.x != 0f || inputVector.y != 0f)
        {
            myRigidbody.MovePosition(myRigidbody.position + inputVector * movementSpeed * Time.deltaTime); 

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void ChangeWeapon()
    {
        if (sword != null && bow != null)
        {
            if (Input.GetButtonDown("Fire3") && Time.time > nextAttack)
            {
                if (mele == true)
                {
                    sword.SetActive(false);
                    bow.SetActive(true);

                    mele = false;
                    nextAttack = Time.time + coldownAttack;
                }
                else if (mele == false)
                {
                    bow.SetActive(false);
                    sword.SetActive(true);

                    mele = true;
                    nextAttack = Time.time + coldownAttack;
                }
            }
        }
    }
}