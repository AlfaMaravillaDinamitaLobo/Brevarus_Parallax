using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryText : MonoBehaviour {

	public Color initColor;
	public Color finishColor;
	public float speed;

	private float counter;
	private float colorTime;
	private HistoryFade historyFade;
	private bool textAppear;

	void Start(){
		textAppear = false;
		colorTime = 0f;
		counter = 0f;
		historyFade = transform.parent.GetComponent<HistoryFade> ();

		Renderer renderer = this.gameObject.GetComponent<Renderer> ();
		renderer.sortingOrder = 21;
	}

	void Update () {
		counter += Time.deltaTime;

		if (counter >= historyFade.appearTime && !textAppear) {
			colorTime += Time.deltaTime;
			GetComponent<TextMesh> ().color = Color.Lerp (initColor, finishColor, colorTime * speed);
		}

		if (counter >= historyFade.disappearTime) {
			colorTime += Time.deltaTime;
			GetComponent<TextMesh> ().color = Color.Lerp (finishColor, initColor, colorTime * speed);
		}

		if (counter >= historyFade.appearTime + 2 && !textAppear) {
			textAppear = true;
			colorTime = 0f;
		}
	}

	public void SetText(string text){
		GetComponent<TextMesh> ().text = text;
	}
}
