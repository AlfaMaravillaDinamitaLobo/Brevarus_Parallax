using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	
	public float hp, maxHp;

	private GameObject playerOne;

	// Use this for initialization
	void Start () {
		playerOne = Statics.FindPlayerOne ();
		maxHp = playerOne.GetComponent<PlayerCollisionDamage> ().playerHealth;
		hp = maxHp;
	}

	public void TakeDamage(int amount){
		hp = Mathf.Clamp (hp - amount, 0f, maxHp);
		iTween.ScaleTo(gameObject, iTween.Hash("y",hp/maxHp, "time",1, "transition","easeInQuint"));
	}

	public void TakeHealth(int amount){
		hp = Mathf.Clamp (hp + amount, 0f, maxHp);
		iTween.ScaleTo(gameObject, iTween.Hash("y",hp/maxHp, "transition","easeOutElastic"));
	}
}
