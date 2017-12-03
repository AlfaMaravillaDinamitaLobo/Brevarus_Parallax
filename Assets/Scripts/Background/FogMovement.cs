using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMovement : MonoBehaviour {

	public float maxSpeed;

	void Start () {

	}

	void Update () {
		var posX = transform.position;
		var velocityX = new Vector3(maxSpeed * (-1) * Time.deltaTime, 0, 0);
		posX += velocityX;

		transform.position = posX;
	}

}
