using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplode : MonoBehaviour {

	public GameObject bulletPrefab1;
	public GameObject bulletPrefab2;
	public GameObject bulletPrefab3;
	public GameObject bulletPrefab4;
	public GameObject bulletPrefab5;
	public GameObject bulletPrefab6;

	public int health = 1;
	public float invulnPeriod = 0;
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
	void Die()
	{
		Instantiate (bulletPrefab1, transform.eulerAngles + 180f * Vector3.up, transform.rotation);
		//Instantiate (bulletPrefab2, transform.position, 60f);
		//Instantiate (bulletPrefab3, transform.position, 120f);
		//Instantiate (bulletPrefab4, transform.position, 180f);
		//Instantiate (bulletPrefab5, transform.position, 240f);
		//Instantiate (bulletPrefab6, transform.position, 300f);
		//Destroy(gameObject);
	}

}
