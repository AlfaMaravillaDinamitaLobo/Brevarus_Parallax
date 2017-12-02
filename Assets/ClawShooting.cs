using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawShooting : MonoBehaviour {

	public GameObject redShoot;
	public GameObject greenShoot;
	private bool readyToShoot;

	public int fireRate;
	private int fireCounter;

	void Start () {
		readyToShoot = true;
		fireCounter = fireRate;
	}

	void Update () {
		if (readyToShoot && fireCounter < 0) {
			Shoot();
			fireCounter = fireRate;
		}
		fireCounter--;
	}

	public void StartFiring(){
		readyToShoot = true;
	}

	public void StopFiring(){
		readyToShoot = false;
	}

	public void Shoot(){
		Vector3 position = transform.position + new Vector3(0.5f, 0.0f, 0.0f);
		Instantiate(redShoot, position, transform.rotation);
		Instantiate(greenShoot, position, transform.rotation);
	}
}
