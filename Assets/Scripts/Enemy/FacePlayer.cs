using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {

    private float rotSpeed = 90f;
	private GameObject[] players = new GameObject[2];

	void Update () {
		players = Statics.FindPlayers();

		if (players.Length != 0) {
			GameObject player = FindNearest ();

			Vector3 dir = player.transform.position - transform.position;
			//Este vector indica la distancia a la que está player

			dir.Normalize ();
			//Si antes dir era (-10, 0, 0), lo transforma en (-1, 0, 0)

			float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
			Quaternion desiredRotation = Quaternion.Euler (0, 0, zAngle);
			float allowedRotation = rotSpeed * Time.deltaTime;
	        
			transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRotation, allowedRotation);
		}
    }

	private GameObject FindNearest(){
		GameObject returnPlayer = players [0];

		if (players.Length == 2) {
			float distPlayer1 = Vector3.Distance(players [0].transform.position,transform.position);
			float distPlayer2 = Vector3.Distance(players [1].transform.position,transform.position);

			if (distPlayer2 < distPlayer1)
				returnPlayer = players [1];
		}

		return returnPlayer;
	}
}
