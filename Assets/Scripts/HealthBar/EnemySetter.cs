using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetter : MonoBehaviour {

	public Vector3 lalala;

	public void SetEnemy(GameObject enemy){
		
		foreach (Transform child in transform) {
			if (child.name == "EnemyHealthBar") {
				child.GetComponent<HealthBarEnemy> ().enemy = enemy;
			}
		}

	}

	void Update()
	{
		transform.localScale = new Vector3(1f,1f,1f);
		transform.position = new Vector3(0.01f,11.2f,0f);
	}
}
