using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;

    /*void start()
    {
        {
            InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}