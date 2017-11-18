using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDamage : MonoBehaviour {

    public GameObject deathEffect;
    public GameObject powerUp;

    public float invulnPeriod;
    float invulnTimer;
    int correctLayer;
    public int health;

    void Start()
    {
        correctLayer = gameObject.layer;
        invulnTimer = 0;
    }

    void Update()
    {
        invulnTimer -= Time.deltaTime;
        if (invulnTimer <= 0)
        {
            gameObject.layer = correctLayer;
        }
        if (health <= 0)
        {
            Die();
        }
    }

    public void ReceiveDamage(int damage)
    {
        health = health - damage;
        invulnTimer = invulnPeriod;
        gameObject.layer = 10;
    }

    void Die()
    {
        int random = Random.Range(0, 10);
        if (random == 1)
        {
           Instantiate(powerUp, transform.position, transform.rotation);
        }
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
