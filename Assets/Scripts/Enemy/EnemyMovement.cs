using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float maxSpeed = 5f;
	private float counter = 0f;

    void Update()
    {
		counter += Time.deltaTime;

		Vector3 posY = transform.position;
		Vector3 velocityY = new Vector3 (0, maxSpeed * Time.deltaTime, 0);
		posY += transform.rotation * velocityY;
		transform.position = posY;

		if (counter >= Statics.TimePerWave () && GetComponent<FacePlayer> ().enabled) {
			GetComponent<FacePlayer> ().enabled = false;
			maxSpeed = 15f;
			Destroy (gameObject, 2);
		}
    }
}


