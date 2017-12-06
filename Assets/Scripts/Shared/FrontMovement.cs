using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontMovement : MonoBehaviour {

	public float maxSpeed = 0.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 posY = transform.position;
		Vector3 velocityY = new Vector3 (0, maxSpeed * Time.deltaTime, 0);
		posY += transform.rotation * velocityY;
		transform.position = posY;
	}
}
