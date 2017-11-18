using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDamage : MonoBehaviour {

    public int playerHealth;  
    public float invulnerabilityTimer;  

    float invulnerabilityCounter = 0;  
    int correctLayer; 
    
    public GameObject deathEffect;  

    void Start()
    {
        correctLayer = gameObject.layer;
    }

    void Update()
    {
        invulnerabilityCounter -= Time.deltaTime;
        if (invulnerabilityCounter <= 0)
        {
            gameObject.layer = correctLayer;
        }
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Boss")
        {
            playerHealth--;
            other.GetComponent<EnemyCollisionDamage>().ReceiveDamage(1);
        }
    }

    public void ReceiveDamage(int damage)
    {
        playerHealth = playerHealth - damage;
        invulnerabilityCounter = invulnerabilityTimer;
        gameObject.layer = LayerMask.NameToLayer("Invulnerable");
    }

    public void Recover()
    {
        playerHealth = Mathf.Min(playerHealth + 6, 12);
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
