using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDamage : MonoBehaviour {

    public GameObject deathEffect;
    public GameObject powerUp;

	public GameObject healthBar;

    public float invulnPeriod;
    public int health;
	public int maxHp;

	private bool damaged;
	private float invulnTimer;
	private int correctLayer;

    void Start()
    {
        correctLayer = gameObject.layer;
        invulnTimer = 0;
		damaged = false;
		maxHp = health;
    }

    void Update()
    {
        invulnTimer -= Time.deltaTime;

		if (invulnTimer > 0)
			damaged = true;

        if (invulnTimer <= 0)
        {
            gameObject.layer = correctLayer;
			damaged = false;
        }

        if (health <= 0)
            Die();
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			ReceiveDamage (5);
			other.GetComponent<PlayerCollisionDamage>().ReceiveDamage (3);
		}
	}

    public void ReceiveDamage(int damage)
    {
		if (!damaged) {
			health = health - damage;
			invulnTimer = invulnPeriod;
			gameObject.layer = 10;

			healthBar.GetComponent<EnemySetter>().SetEnemy(gameObject);

			GameObject bar= Instantiate(healthBar, 
										new Vector3(640f,-23.6f,Statics.UIProperties().getZPositionEnemyBar()),
										Quaternion.Euler(0,0,0));
			bar.transform.localScale = new Vector3 (1, 1, 1);
			bar.transform.SetParent (Statics.getUIGameObject());
		}
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
