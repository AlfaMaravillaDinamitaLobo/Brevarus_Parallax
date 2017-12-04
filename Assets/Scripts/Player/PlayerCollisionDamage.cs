using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDamage : MonoBehaviour {
    
    public GameObject deathEffect;

	private float maxHealt;
	private float playerHealth;
	public float invulnerabilityTimer;
	private int lifes;

	private bool damaged;
	private GameObject guiPlayer;
	private float invulnerabilityCounter = 0;  
	private int correctLayer;

    void Start()
    {
		guiPlayer = GetComponent<GuiPlayer> ().guiPlayer;
		playerHealth = guiPlayer.GetComponent<StatsPlayer> ().hp;
		maxHealt = guiPlayer.GetComponent<StatsPlayer> ().maxHp;
		invulnerabilityTimer = guiPlayer.GetComponent<StatsPlayer>().invulnerabilityTimer;
		lifes = 3;

		correctLayer = gameObject.layer;
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

		if (playerHealth <= 0) {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
			this.ReceiveDamage(1);
            other.GetComponent<EnemyCollisionDamage>().ReceiveDamage(1);
        }
		if (other.tag == "MiniBoss") {
			this.ReceiveDamage(1);
			other.GetComponent<MiniBossColisionDmg>().ReceiveDamage(1);
		}
		if (other.tag == "Boss") {
			this.ReceiveDamage(1);
			other.GetComponent<BossCollisionDamage>().ReceiveDamage(1);
		}
    }

    public void ReceiveDamage(int damage)
    {
		if (!damaged) {
			guiPlayer.SendMessage ("TakeDamage", damage);
			playerHealth = playerHealth - damage;
			invulnerabilityCounter = invulnerabilityTimer;
			gameObject.layer = LayerMask.NameToLayer ("Invulnerable");
		}
    }

    public void Recover()
    {
		playerHealth = Mathf.Min(playerHealth + 6, maxHealt);
		guiPlayer.SendMessage ("TakeHealth", 6);
    }

	public void ExtraLife(){
		lifes++;
	}

    void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
		lifes--;
        Destroy(gameObject);
    }
}
