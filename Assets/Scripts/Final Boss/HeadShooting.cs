using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShooting : MonoBehaviour {

	public ParticleSystem particles;
	public int specialInterval;
	private int specialCounter;

	void Start () {
		specialCounter = specialInterval;
	}

	void Update () {
		if (specialCounter < 0) {
			FireBeam ();
			specialCounter = specialInterval;
		}
		specialCounter--;
		
	}

	public void FireBeam(){
		Debug.Log ("Special Boss Attack");
		Instantiate (particles, transform);
	}
}
