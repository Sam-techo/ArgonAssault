using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathParticle;
    [SerializeField] GameObject hitParticle;
    [SerializeField] int scorePerHit;
    [SerializeField] int hitPoints = 10;

    ScoreBoard scoreBoard;
    GameObject spawnHolder;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        spawnHolder = GameObject.FindWithTag("SpawnHolder");
        Rigidbody enemyRb = gameObject.AddComponent<Rigidbody>();
        enemyRb.useGravity = false;
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessScore();


        if (hitPoints < 1)
        {
            KillEnemy();
        }
        

    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathParticle, transform.position, Quaternion.identity);
        vfx.transform.parent = spawnHolder.transform;
        Destroy(gameObject);
    }

    private void ProcessScore()
    {
        GameObject vfx = Instantiate(hitParticle, transform.position, Quaternion.identity);
        vfx.transform.parent = spawnHolder.transform;
        hitPoints--;
        if (hitPoints < 1)
        {
            scoreBoard.IncreaseScore(scorePerHit);
        }
        
    }
}
