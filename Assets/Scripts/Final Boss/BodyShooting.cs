using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyShooting : MonoBehaviour {

	private bool canShoot;
	public GameObject redShot;
	public GameObject greenShot;

	public int fireRate;
	private int fireCounter;
	public bool isRed;
	public int colorRate;
	private int colorCounter;

	void Start () {
		canShoot = false;
		isRed = true;
		colorCounter = colorRate;
	}

	void Update () {
		if (canShoot && fireCounter < 0 && isRed) {
			Shoot(redShot);
			fireCounter = fireRate;
		}
		if (canShoot && fireCounter < 0 && !isRed) {
			Shoot(greenShot);
			fireCounter = fireRate;
		}
		fireCounter--;
		colorCounter--;
		if (colorCounter <= 0) {
			isRed = !isRed;
			colorCounter = colorRate;
		}
	}

	public void BeginShooting(){
		canShoot = true;
	}

	public void Shoot(GameObject proyectile){
		Vector3 position = transform.position + new Vector3 (0.0f, -2.0f, 0.0f);
		Instantiate (proyectile, position, transform.rotation);
	}
}
