using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public int waypointIndex;
    public float moveSpeed;
    public Animator animator;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void FixedUpdate()
    {
        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        transform.position = Vector3.MoveTowards (transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        animator.SetBool("IsWalking", true);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex ++;
        }

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }

        if (this.transform.position.x < waypoints[waypointIndex].transform.position.x) //Llendo a la derecha
        {
            animator.SetBool("GoingLeft", false);
        }
        else if(this.transform.position.x > waypoints[waypointIndex].transform.position.x) //Llendo a la izquierda
        {
            animator.SetBool("GoingLeft", true);
        }
    }
}