using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapContact : MonoBehaviour
{
    public Animator animator;
    public bool constant;
    public AudioSource trapSound;

    private void Start()
    {
        animator.SetBool("Constant", constant);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("OnContact", true);
    }

    private void ReproduceSound()
    {
        trapSound.Play();
    }
}
