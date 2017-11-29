using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour {

	public float power, maxPower;

	private GameObject playerOne;

	// Use this for initialization
	void Start () {
		playerOne = Statics.FindPlayerOne ();
		power = playerOne.GetComponent<RedShoot> ().power;
		maxPower = 100f;
	}

	public void TakePower(float amount){
		power = Mathf.Clamp (power + amount, 0f, maxPower);
		iTween.ScaleTo(gameObject, iTween.Hash("y",power/maxPower, "time",1, "transition","easeInQuint"));
	}

	public void usePower(){
		power = 0f;
		iTween.ScaleTo(gameObject, iTween.Hash("y",power/maxPower, "transition","easeOutElastic"));
	}
}
