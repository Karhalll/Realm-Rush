using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan = null;

    [Space(10)]

    [Tooltip("Shooting distance in cube(grid size) unit.")]
    [SerializeField] float shootDistance = 3f;

    ParticleSystem.EmissionModule bulletFire;
    Transform targetEnemy = null;

    private void Awake() 
    {
        bulletFire = GetComponentInChildren<ParticleSystem>().emission;
    }

    private void Start() 
    {
        shootDistance *= (float)Waypoint.GetGridSize();
        bulletFire.enabled = false;   
    }


    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy) 
        {
            objectToPan.LookAt(targetEnemy);
            HandleAttack();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        EnemyDamage[] sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage tetsEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, tetsEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform currentColesest, Transform newTestSubject)
    {
        float distanceToCurrent = Vector3.Distance(transform.position, currentColesest.position);
        float distanceToTest = Vector3.Distance(transform.position, newTestSubject.position);
        
        if (distanceToCurrent <= distanceToTest)
        {
            return currentColesest;
        }
        else
        {
            return newTestSubject;
        }
    }

    private void HandleAttack()
    {
        if (!targetEnemy) { return; }

        float distance = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);     
        if (distance <= shootDistance)
        {
            Shoot(true);
        }
        else
        {
            if (bulletFire.enabled == true)
            {
                Shoot(false);
            }
        }
    }

    private void Shoot(bool state)
    {
        bulletFire.enabled = state;
    }
}
