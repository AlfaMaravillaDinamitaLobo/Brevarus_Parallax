using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy2Mov : MonoBehaviour {

	private float counter = 0f;
	private float velocidadMovimiento = 5f;
	private bool llegoAlFinal;

	// Update is called once per frame
	void Update () {

		counter += Time.deltaTime;
		if (counter >= Statics.TimePerWave ()) {
			GetComponent<FrontMovement> ().enabled = true;
			GetComponent<FrontMovement> ().maxSpeed = 15f;
			Destroy (gameObject, 2);

			GetComponent<Enemy2Mov> ().enabled = false;
		}

		if (llegoAlFinal) {
			transform.position += Vector3.right * velocidadMovimiento * Time.deltaTime;
		} 
		else {
			transform.position -= Vector3.right * velocidadMovimiento * Time.deltaTime;
		}

		if (transform.position.x >= Properties.limitX() -2f) {
			llegoAlFinal = false;
		}

		if (transform.position.x <= -Properties.limitX() +2f) {
			llegoAlFinal = true;
		}
	}
}
