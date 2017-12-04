using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShoot : MonoBehaviour {

	public GameObject laserPrefab1;
	public GameObject laserPrefab2;
	public GameObject specialPrefab;

    	public float fireDelay = 0.25f;
	public float power = 0f;

    	private float cooldownTimer = 0;
	private GameObject guiPlayer;
	private GameObject specialShoot = null;

	public string botonDeDisparo1 = "Fire1";
	public string botonDeDisparo2 = "Fire2";

	void Start () {
		guiPlayer = GetComponent<GuiPlayer> ().guiPlayer;
		power = guiPlayer.GetComponent<StatsPlayer> ().power;
	}

    void Update () {
        cooldownTimer -= Time.deltaTime;
	if(Input.GetButton(botonDeDisparo1) && cooldownTimer <= 0)
        {
	    	//Debug.Log("Disparo del jugador");
	    	cooldownTimer = fireDelay;

	    	Vector3 offset1 = transform.rotation * new Vector3(0.5f, 1f, 0);
	    	Vector3 offset2 = transform.rotation * new Vector3(-0.5f, 1f, 0);
		GameObject laser1 = Instantiate(laserPrefab1, transform.position + offset1, transform.rotation);
		GameObject laser2 = Instantiate(laserPrefab2, transform.position + offset2, transform.rotation);

		laser1.GetComponent<PlayerLaserCollisionDamage> ().player = gameObject;
		laser2.GetComponent<PlayerLaserCollisionDamage> ().player = gameObject;
        }

		if (Input.GetButton(botonDeDisparo2) && power >= 100f) {
			cooldownTimer = fireDelay;
			specialShoot = Instantiate(specialPrefab, transform.position, transform.rotation);
			guiPlayer.SendMessage ("UsePower");
			power = 0;

			specialShoot.transform.position = transform.position;
			Physics2D.IgnoreLayerCollision (8, 11);
		}
	}

	public void AddPower (float amount) {
		power += amount;
		guiPlayer.SendMessage ("TakePower", amount);
	}
}
