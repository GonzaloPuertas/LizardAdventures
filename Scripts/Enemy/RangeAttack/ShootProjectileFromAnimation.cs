using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectileFromAnimation : MonoBehaviour
{
    public Transform target;
    public Transform shootingPoint;
    public GameObject arrowPrefab;
    public Vector2 distanceToTarget;
    public AudioSource attackSound;

    public void Shoot()
    {
        GameObject spawnedProyectile = Instantiate(arrowPrefab, shootingPoint.position, shootingPoint.rotation);
        distanceToTarget = target.position - transform.position;
        spawnedProyectile.transform.up = distanceToTarget;
        attackSound.Play();
    }
}