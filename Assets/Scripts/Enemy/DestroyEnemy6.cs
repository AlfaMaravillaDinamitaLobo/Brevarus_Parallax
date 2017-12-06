using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy6 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < ((Statics.limitY() + 3f) * (-1f)))
			Destroy (gameObject);
	}
}
