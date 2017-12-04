using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIProperties : MonoBehaviour {

	private float zEnemyHealthBar;

	// Use this for initialization
	void Start () {
		zEnemyHealthBar = -2656.00000f;
	}
	
	// Update is called once per frame
	void Update () {}

	public float getZPositionEnemyBar(){
		zEnemyHealthBar = zEnemyHealthBar - 0.00001f;
		return zEnemyHealthBar;
	}
}
