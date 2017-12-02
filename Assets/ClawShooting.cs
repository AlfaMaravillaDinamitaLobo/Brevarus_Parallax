using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawShooting : MonoBehaviour {

	public GameObject redShoot;
	public GameObject greenShoot;
	private bool readyToShoot;

	public int colorRate;
	public int colorCounter;
	public bool firingRed;

	public int fireRate;
	private int fireCounter;

	void Start () {
		readyToShoot = true;
		fireCounter = fireRate;
		colorCounter = colorRate;
		firingRed = true;
	}

	void Update () {
		if (readyToShoot && fireCounter < 0 && firingRed) {
			Shoot(redShoot);
			fireCounter = fireRate;
		}
		if (readyToShoot && fireCounter < 0 && !firingRed) {
			Shoot(greenShoot);
			fireCounter = fireRate;
		}
		fireCounter--;
		colorCounter--;
		ChangeColor();
	}

	public void StartFiring(){
		readyToShoot = true;
	}

	public void StopFiring(){
		readyToShoot = false;
	}

	public void Shoot(GameObject proyectile){
		Vector3 position = transform.position + new Vector3 (0.5f, 0.0f, 0.0f);
		Instantiate (proyectile, position, transform.rotation);
	}

	public void ChangeColor(){
		if (colorCounter < 0) {
			firingRed = !firingRed;
			colorCounter = colorRate;
		}
	}
}
