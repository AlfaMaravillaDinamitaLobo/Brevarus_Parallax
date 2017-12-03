using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossMovement : MonoBehaviour {

	public float timePerMiniboss = 30f;

	private float counter = 0f;
	private float velocidadMovimiento = 5f;
	private bool llegoAlFinal;

	// Update is called once per frame
	void Update () {

		counter += Time.deltaTime;
		if (counter >= timePerMiniboss) {
			GetComponent<FrontMovement> ().enabled = true;
			GetComponent<FrontMovement> ().maxSpeed = -15f;
			Destroy (gameObject, 2);

			GetComponent<MiniBossMovement> ().enabled = false;
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
