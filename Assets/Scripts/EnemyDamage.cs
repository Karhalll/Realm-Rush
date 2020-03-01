using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticleSystem = null;
    [SerializeField] ParticleSystem deathParticleSystem = null;
    
    private void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hitPoints--;
        hitParticleSystem.Play();
    }

    private void KillEnemy()
    {
        ParticleSystem deathVFX = Instantiate(deathParticleSystem, transform.position, Quaternion.identity); 
        float deathDelay = deathVFX.main.duration;
        Destroy(deathVFX.gameObject, deathDelay);
        Destroy(gameObject);
    }
}
