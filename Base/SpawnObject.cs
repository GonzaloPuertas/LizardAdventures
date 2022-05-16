using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject projectilePrefab;
    public KeyCode shootKey;

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}