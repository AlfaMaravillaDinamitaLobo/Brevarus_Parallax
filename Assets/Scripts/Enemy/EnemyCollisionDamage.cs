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

	private SpriteRenderer sprite;
	private int colorTimer;
	private int colorCounter;

    void Start()
    {
        correctLayer = gameObject.layer;
        invulnTimer = 0;
		sprite = this.GetComponent<SpriteRenderer> ();
		colorTimer = 7;
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
		colorCounter--;
		if (colorCounter < 0) {
			sprite.color = Color.white;
		}
    }

    public void ReceiveDamage(int damage)
    {
        health = health - damage;
		Color newColor = new Color(1f, 0f, 0f, 0.5f);
		sprite.color = newColor;
		colorCounter = colorTimer;
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
