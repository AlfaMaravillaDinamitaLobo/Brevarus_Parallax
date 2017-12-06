using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour {

	public float hp, maxHp;
	public float power, maxPower;
	public float score;
	public float invulnerabilityTimer;
	public int lifes;

	public GameObject player;

	void Awake(){
		Transform lifesUI = Statics.TransformOfChildByName(gameObject.transform,"Lifes");
		lifesUI.GetComponent<Text>().text = "Lifes : " + 3;
	}

	// Use this for initialization
	void Start () {
		if (score == null) {
			score = 0;
		}

	}

	public void TakeDamage(int amount){
		hp = Mathf.Clamp (hp - amount, 0f, maxHp);
		Transform healthBar = Statics.TransformOfChildByName(Statics.TransformOfChildByName(gameObject.transform,"Health"),"HealthBar");
		iTween.ScaleTo(healthBar.gameObject, iTween.Hash("y",hp/maxHp, "time",1, "transition","easeInQuint"));
	}

	public void TakeHealth(int amount){
		hp = Mathf.Clamp (hp + amount, 0f, maxHp);
		Transform healthBar = Statics.TransformOfChildByName(Statics.TransformOfChildByName(gameObject.transform,"Health"),"HealthBar");
		iTween.ScaleTo(healthBar.gameObject, iTween.Hash("y",hp/maxHp, "transition","easeOutElastic"));
	}

	public void TakePower(float amount){
		power = Mathf.Clamp (power + amount, 0f, maxPower);
		Transform powerBar = Statics.TransformOfChildByName(Statics.TransformOfChildByName(gameObject.transform,"Power"),"PowerBar");
		iTween.ScaleTo(powerBar.gameObject, iTween.Hash("y",power/maxPower, "time",1, "transition","easeInQuint"));
	}

	public void UsePower(){
		power = 0f;
		Transform powerBar = Statics.TransformOfChildByName(Statics.TransformOfChildByName(gameObject.transform,"Power"),"PowerBar");
		iTween.ScaleTo(powerBar.gameObject, iTween.Hash("y",power/maxPower, "transition","easeOutElastic"));
	}

	public void AddScore(int score){
		this.score = this.score + score;
		Transform scoreGUI = Statics.TransformOfChildByName(gameObject.transform,"Score");
		scoreGUI.GetComponent<Text>().text = "Score : " + this.score;
	}

	public void SetLifes(int lifes){
		this.lifes = lifes;
		Transform lifesUI = Statics.TransformOfChildByName(gameObject.transform,"Lifes");
		lifesUI.GetComponent<Text>().text = "Lifes : " + this.lifes;
	}

	public void LooseLife(){
		lifes--;
		Transform lifesUI = Statics.TransformOfChildByName(gameObject.transform,"Lifes");
		lifesUI.GetComponent<Text>().text = "Lifes : " + this.lifes;
	}

	public void ExtraLife(){
		lifes++;
		Transform lifesUI = Statics.TransformOfChildByName(gameObject.transform,"Lifes");
		lifesUI.GetComponent<Text>().text = "Lifes : " + this.lifes;
	}
}
