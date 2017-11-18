using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossColisionDmg : MonoBehaviour {

	public int health = 50;
	public float invulnPeriod = 0.2f;
	float invulnTimer = 0;
	int correctLayer;


	void Start()
	{
		correctLayer = gameObject.layer;
	}

	void OnTriggerEnter2D()
	{
		Debug.Log("Activado el trigger");
		health--;
		invulnTimer = invulnPeriod;
		gameObject.layer = 10;
		GetComponent<Animator> ().Play("OnHit");
	}

	void Update()
	{
		invulnTimer -= Time.deltaTime;
		if(invulnTimer <= 0)
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
    }

	void Die()
	{
		Destroy(gameObject);
	}
}
