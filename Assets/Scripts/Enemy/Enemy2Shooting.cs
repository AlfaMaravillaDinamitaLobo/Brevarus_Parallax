using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Shooting : MonoBehaviour{
	
	public Vector3 bulletOffset1 = new Vector3(-1.45f, -1.95f, 0);
	public Vector3 bulletOffset2 = new Vector3 (-1.45f, -1.95f, 0);  

	public GameObject bulletPrefab1;
	public GameObject bulletPrefab2;

	public float fireDelay = 0.50f;
	float cooldownTimer = 0;

	void Update()
	{
		cooldownTimer -= Time.deltaTime;
		if (cooldownTimer <= 0)
		{
			Debug.Log("Disparo del enemigo");
			cooldownTimer = fireDelay;

			Vector3 offset1 = transform.rotation * bulletOffset1;
			Vector3 offset2 = transform.rotation * bulletOffset2;

			Instantiate(bulletPrefab1, transform.position + offset1, transform.rotation);
			Instantiate(bulletPrefab2, transform.position + offset2, transform.rotation);

		}
	}
}

