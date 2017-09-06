using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float maxSpeed = 15f;

    void Start () {
		
	}

	void Update () {

        //MOVIMIENTO DEL JUGADOR

        Vector3 posY = transform.position;
        Vector3 velocityY = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        posY += velocityY;
        transform.position = posY;

        Vector3 posX = transform.position;
        Vector3 velocityX = new Vector3(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, 0, 0);
        posX += velocityX;
        transform.position = posX;
    }
}




