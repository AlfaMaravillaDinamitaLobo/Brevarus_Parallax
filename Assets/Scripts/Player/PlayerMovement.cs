using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float maxSpeed = 15f;
	public string verticalMovement = "Vertical";
	public string horizontalMovement = "Horizontal";

	void Update () {

		Vector3 posY = transform.position;

		if (Input.GetAxis (verticalMovement) < 0  && transform.position.y >= -10f) {
			Vector3 velocityY = new Vector3 (0, Input.GetAxis (verticalMovement) * maxSpeed * Time.deltaTime, 0);
			posY += velocityY;
			transform.position = posY;
		}
		if (Input.GetAxis (verticalMovement) > 0 && transform.position.y <= 10f) {
			Vector3 velocityY = new Vector3 (0, Input.GetAxis (verticalMovement) * maxSpeed * Time.deltaTime, 0);
			posY += velocityY;
			transform.position = posY;
		}

		Vector3 posX = transform.position;

		if (Input.GetAxis (horizontalMovement) < 0 && transform.position.x >= -13.5f) {
			Vector3 velocityX = new Vector3(Input.GetAxis(horizontalMovement) * maxSpeed * Time.deltaTime, 0, 0);
			posX += velocityX;
			transform.position = posX;
		}
		if (Input.GetAxis (horizontalMovement) > 0 && transform.position.x <= 13.5f) {
			Vector3 velocityX = new Vector3(Input.GetAxis(horizontalMovement) * maxSpeed * Time.deltaTime, 0, 0);
			posX += velocityX;
			transform.position = posX;
		}
    }
}




