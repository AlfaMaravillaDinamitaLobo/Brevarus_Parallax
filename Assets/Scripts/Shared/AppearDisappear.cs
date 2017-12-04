using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearDisappear : MonoBehaviour {

	public Color initColor;
	public Color finishColor;
	public float speed;

	private float counter;
	private bool mustAppear;
	private float switchTime;

	void Start(){
		mustAppear = true;
		counter = 0f;
		switchTime = 1.5f;

		Renderer renderer = this.gameObject.GetComponent<Renderer> ();
		renderer.sortingOrder = 21;
	}

	void Update () {
		counter += Time.deltaTime;

		if (counter < switchTime && mustAppear) {
			GetComponent<SpriteRenderer> ().color = Color.Lerp (initColor, finishColor, counter * speed);
		}

		if (counter < switchTime && !mustAppear) {
			GetComponent<SpriteRenderer> ().color = Color.Lerp (finishColor, initColor, counter * speed);
		}

		if (mustAppear && counter >= switchTime) {
			counter = 0;
			mustAppear = false;
		} 

		if (!mustAppear && counter >= switchTime) {
			counter = 0;
			mustAppear = true;
		}
	}
}
