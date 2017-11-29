using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDamage : MonoBehaviour {

    public int playerHealth;  
    public float invulnerabilityTimer;  
    public GameObject deathEffect;
	public GameObject healthBar;

	private float invulnerabilityCounter = 0;  
	private int correctLayer; 
	private int maxHealt;
	private bool damaged;

    void Start()
    {
        correctLayer = gameObject.layer;
		maxHealt = playerHealth;
		damaged = false;
    }

    void Update()
	{
		invulnerabilityCounter -= Time.deltaTime;

		if (invulnerabilityCounter > 0)
			damaged = true;

		if (invulnerabilityCounter <= 0) {
			gameObject.layer = correctLayer;
			damaged = false;
		}

        if (playerHealth <= 0)
            Die();
    }

    public void ReceiveDamage(int damage)
    {
		if (!damaged) {
			healthBar.SendMessage ("TakeDamage", damage);
			playerHealth = playerHealth - damage;
			invulnerabilityCounter = invulnerabilityTimer;
			gameObject.layer = LayerMask.NameToLayer ("Invulnerable");
		}
    }

    public void Recover()
    {
		playerHealth = Mathf.Min(playerHealth + 6, maxHealt);
		healthBar.SendMessage ("TakeHealth", 6);
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
