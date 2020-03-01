using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] int scoreForKill = 17;
    [SerializeField] ParticleSystem hitParticleSystem = null;
    [SerializeField] ParticleSystem deathParticleSystem = null;

    BaseHealth baseHealth;

    private void Awake() 
    {
        baseHealth = FindObjectOfType<BaseHealth>();
    }
    
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
        UpdateScore();

        ParticleSystem deathVFX = Instantiate(deathParticleSystem, transform.position, Quaternion.identity); 
        float deathDelay = deathVFX.main.duration;
        Destroy(deathVFX.gameObject, deathDelay);
        Destroy(gameObject);
    }

    private void UpdateScore()
    {
        baseHealth.UpdateScoreText(scoreForKill);
    }
}
