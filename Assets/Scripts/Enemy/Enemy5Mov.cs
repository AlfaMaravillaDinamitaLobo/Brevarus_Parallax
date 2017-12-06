using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy5Mov : MonoBehaviour {

	public float dirOrientation = -1;
	public float rotOrientation = 1;
	private int rotationLeft = 1;

	private float counter = 0f;
	private float lifeCounter = 0f;
	public float maxSpeed = 20f;

	private bool movementTime = true;
	private bool rotationTime = false;

	// Update is called once per frame
	void Update () {
		lifeCounter += Time.deltaTime;

		if (movementTime) {
			counter += Time.deltaTime;
			Vector3 posY = transform.position;
			Vector3 velocityY = new Vector3 (0, maxSpeed * Time.deltaTime, 0);
			posY += transform.rotation * velocityY;
			transform.position = posY;
		}

		if (counter >= 1f) {
			movementTime = false;
			rotationTime = true;
			counter = 0f;
		}

		if (rotationTime && rotationLeft != 0) {
			iTween.RotateTo(gameObject, iTween.Hash("z", transform.rotation.z + (90 * rotOrientation), "time",2f));
			rotationLeft--;
			rotationTime = false;
			movementTime = true;

			if (rotationLeft == 0) {
				rotationLeft = 2;
				rotOrientation *= -1;
			}
		}

		if (lifeCounter > Statics.TimePerWave() && (transform.position.y > Statics.limitY() +3 || transform.position.y < (Statics.limitY()+3f) * (-1f))) {
			Destroy (gameObject);
		}
	}
}
