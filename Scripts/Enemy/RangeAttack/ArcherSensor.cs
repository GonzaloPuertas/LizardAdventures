using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSensor : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("Attack", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("Attack", false);
    }
}
