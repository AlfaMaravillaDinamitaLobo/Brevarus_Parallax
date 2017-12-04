using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShoot : MonoBehaviour {

	public GameObject laserPrefab1;
	public GameObject laserPrefab2;
	public GameObject specialPrefab;

    public float fireDelay = 0.25f;
	public float power = 0f;
	public float multipleShootTimer;
	private float multipleShootCounter;

    private float cooldownTimer = 0;
	private GameObject guiPlayer;
	private GameObject specialShoot = null;
	private bool multipleShoot;

	public string botonDeDisparo1 = "Fire1";
	public string botonDeDisparo2 = "Fire2";

	void Start () {
		guiPlayer = GetComponent<GuiPlayer> ().guiPlayer;
		power = guiPlayer.GetComponent<StatsPlayer> ().power;
		multipleShoot = false;
		multipleShootCounter = 0;
	}

    void Update () {
        cooldownTimer -= Time.deltaTime;
		if(Input.GetButton(botonDeDisparo1) && cooldownTimer <= 0 && !multipleShoot)
        {
	    	cooldownTimer = fireDelay;

	    	Vector3 offset1 = transform.rotation * new Vector3(0.5f, 1f, 0);
	    	Vector3 offset2 = transform.rotation * new Vector3(-0.5f, 1f, 0);
			GameObject laser1 = Instantiate(laserPrefab1, transform.position + offset1, transform.rotation);
			GameObject laser2 = Instantiate(laserPrefab1, transform.position + offset2, transform.rotation);

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

		if (Input.GetButton (botonDeDisparo1) && cooldownTimer <= 0 && multipleShoot) {
			cooldownTimer = fireDelay;

			Vector3 offset1 = transform.rotation * new Vector3(1.0f, 1f, 0);
			Vector3 offset2 = transform.rotation * new Vector3(-1.0f, 1f, 0);
			Vector3 offset3 = transform.rotation * new Vector3(0.0f, 1f, 0);
			GameObject laser1 = Instantiate(laserPrefab2, transform.position + offset1, transform.rotation);
			GameObject laser2 = Instantiate(laserPrefab2, transform.position + offset2, transform.rotation);
			GameObject laser3 = Instantiate(laserPrefab2, transform.position + offset3, transform.rotation);

			laser1.GetComponent<PlayerLaserCollisionDamage> ().player = gameObject;
			laser2.GetComponent<PlayerLaserCollisionDamage> ().player = gameObject;
			laser3.GetComponent<PlayerLaserCollisionDamage> ().player = gameObject;
		}
		multipleShootCounter--;
		if (multipleShootCounter <= 0) {
			multipleShoot = false;
		}
	}

	public void AddPower (float amount) {
		power += amount;
		guiPlayer.SendMessage ("TakePower", amount);
	}

	public void MultipleShoot(){
		multipleShoot = true;
		multipleShootCounter = multipleShootTimer;
	}

	public void ActivateShield(){

	}
}
