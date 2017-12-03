using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLaser : MonoBehaviour {

	public float invulnPeriod = 0;
	public int damage;

	private float invulnTimer = 0;
	private int correctLayer;
	private bool alreadyHurt;


	void Start()
	{
		alreadyHurt = false;
		correctLayer = gameObject.layer;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" && !alreadyHurt){
			if (Statics.TransformOfChildByName (other.transform, "Energy Field").GetComponent<ShieldController> ().mode != "Red") {
				alreadyHurt = true;
				other.GetComponent<PlayerCollisionDamage> ().ReceiveDamage (damage);
				invulnTimer = invulnPeriod;
				gameObject.layer = 10;
			}
		}
	}

	void Update()
	{
		invulnTimer -= Time.deltaTime;
		if(invulnTimer <= 0)
		{
			gameObject.layer = correctLayer;
		}
	}
}
