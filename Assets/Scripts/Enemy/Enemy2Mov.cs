using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy2Mov : MonoBehaviour {

	float velocidadMovimiento = 8f;
	bool llegoAlFinal;

	// Update is called once per frame
	void Update () {

		if (llegoAlFinal) {
			transform.position += Vector3.right * velocidadMovimiento * Time.deltaTime;
		} 
		else {
			transform.position -= Vector3.right * velocidadMovimiento * Time.deltaTime;
		}

		if (transform.position.x >= 7.1f) {
			llegoAlFinal = false;
		}

		if (transform.position.x <= -7.1f) {
			llegoAlFinal = true;
		}
	}
}
