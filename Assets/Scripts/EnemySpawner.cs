using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyPrefab = null;
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 3f;

    void Start()
    {
        HandleSpawning();
    }

    private void HandleSpawning()
    {
        StartCoroutine(SpawningEnemies());
    }

    private IEnumerator SpawningEnemies()
    {
        while(true)
        {
            Instantiate(enemyPrefab, transform);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
