using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDamage : MonoBehaviour {
    
    public GameObject deathEffect;

	private float maxHealt;
	public float playerHealth;
	public float invulnerabilityTimer;
	public int lifes;

	private bool damaged;
	private GameObject guiPlayer;
	private float invulnerabilityCounter = 0;  
	private int correctLayer;

	public bool disabled;
	public float restartTimer;
	private float restartCounter;

    void Start()
    {
		guiPlayer = GetComponent<GuiPlayer> ().guiPlayer;
		playerHealth = guiPlayer.GetComponent<StatsPlayer> ().hp;
		maxHealt = guiPlayer.GetComponent<StatsPlayer> ().maxHp;
		invulnerabilityTimer = guiPlayer.GetComponent<StatsPlayer>().invulnerabilityTimer;
		lifes = 3;

		correctLayer = gameObject.layer;
		damaged = false;

		disabled = false;
		restartCounter = restartTimer;
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

		if (lifes > 0 && playerHealth <= 0 && !disabled) {
			Defeat ();
		}

		if (lifes <= 0 && playerHealth <= 0 && !disabled) {
            Die();
        }
		if (restartCounter > 0 && disabled) {
			restartCounter--;
		}
		if (restartCounter <= 0 && disabled) {
			disabled = false;
			restartCounter = restartTimer;
			Revive ();
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

	public void Defeat(){
		Instantiate(deathEffect, transform.position, transform.rotation);
		this.gameObject.GetComponent<PlayerMovement> ().enabled = false;
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		this.gameObject.GetComponent<RedShoot> ().enabled = false;
		this.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		this.gameObject.layer = 8;
		this.gameObject.tag = "Untagged";
		this.gameObject.GetComponentInChildren<ShieldController> ().enabled = false;
		SpriteRenderer[] list = this.gameObject.GetComponentsInChildren<SpriteRenderer> ();
		foreach (SpriteRenderer renderer in list)
		{
			renderer.enabled = false;  
		}
		disabled = true;
		restartCounter = restartTimer;
		lifes--;
	}

	public void Revive(){
		this.gameObject.GetComponent<PlayerMovement> ().enabled = true;
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		this.gameObject.GetComponent<RedShoot> ().enabled = true;
		this.gameObject.GetComponent<CircleCollider2D> ().enabled = true;
		this.gameObject.layer = 6;
		this.gameObject.tag = "Player";
		this.gameObject.GetComponentInChildren<ShieldController> ().enabled = true;
		SpriteRenderer[] list = this.gameObject.GetComponentsInChildren<SpriteRenderer> ();
		foreach (SpriteRenderer renderer in list)
		{
			renderer.enabled = true;  
		}
		playerHealth = maxHealt;
		guiPlayer.SendMessage ("TakeHealth", maxHealt);
	}

    void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
