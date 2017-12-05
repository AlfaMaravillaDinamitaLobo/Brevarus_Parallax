using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollisionDamage : MonoBehaviour {

	public GameObject deathEffect;

	public float invulnPeriod;
	float invulnTimer;
	int correctLayer;
	public int health;

	private SpriteRenderer sprite;
	private int colorTimer;
	private int colorCounter;

	public bool isBody;
	private int destroyedParts;
	private bool canReceiveDamage;

	void Start()
	{
		correctLayer = gameObject.layer;
		invulnTimer = 0;
		sprite = this.GetComponent<SpriteRenderer> ();
		colorTimer = 7;
		destroyedParts = 0;
		canReceiveDamage = false;
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
			sprite.material.color = Color.white;
		}
		if (isBody) {
			BodyCheck ();
		}
	}

	public void ReceiveDamage(int damage)
	{
		if (!isBody || (isBody && canReceiveDamage)) {
			health = health - damage;
			Color newColor = new Color(1f, 0f, 0f, 0.5f);
			sprite.material.color = newColor;
			colorCounter = colorTimer;
			invulnTimer = invulnPeriod;
			gameObject.layer = 10;
		}

	}

	public void PartDestroyed(){
		destroyedParts++;
	}

	public void BodyCheck(){
		if (destroyedParts >= 5) {
			canReceiveDamage = true;
			this.gameObject.GetComponent<BodyShooting> ().BeginShooting();
		}
	}

	void Die()
	{
		if (!isBody) {
			this.gameObject.GetComponentInParent<BossMovement>().Faster();
		}
		Instantiate(deathEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
