using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour {

	public Color initColor;
	public Color finishColor;
	public float speed;

	private float counter;

	void Start() {
		counter = 0f;
	}

	void Update () {
		counter += Time.deltaTime;
		GetComponent<SpriteRenderer> ().color = Color.Lerp (initColor, finishColor, counter * speed);

		if(initColor.a == 0 && GetComponent<SpriteRenderer> ().color.a >= 1)
			Destroy(gameObject);

		if(initColor.a == 1 && GetComponent<SpriteRenderer> ().color.a <= 0)
			Destroy(gameObject);
	}
}
