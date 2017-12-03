using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryFade : MonoBehaviour {

	public Material initialColor;
	public float fadeVelocity;
	public float appearTime;
	public float disappearTime;
	public float destroyTime;

	private float time;
	private float alpha;
	private float alphaMax;
	private float alphaMin;
	private bool alphaHigh;
	private bool alphaLow;

	// Use this for initialization
	void Start () {
		alpha = 0f;
		alphaMax = 0.7f;
		alphaMin = 0f;
		time = 0;
		alphaHigh = false;
		alphaLow = false;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if(time >= appearTime && alpha <= alphaMax && !alphaHigh){
			gameObject.GetComponent<Renderer>().material = initialColor;
			initialColor.color = new Color(0,0,0,alpha);
			alpha += fadeVelocity * Time.deltaTime;
		}

		if(time >= disappearTime && alpha >= alphaMin && !alphaLow){
			gameObject.GetComponent<Renderer>().material = initialColor;
			initialColor.color = new Color(0,0,0,alpha);
			alpha -= fadeVelocity * Time.deltaTime;
		}

		if (alpha > alphaMax) alphaHigh = true;
		if (alpha <= alphaMin && alphaHigh) alphaLow = true;

		if(time >= destroyTime) Destroy(gameObject);
	}

	public void SetText(string text){
		Statics.TransformOfChildByName (gameObject.transform, "HistoryText").SendMessage ("SetText", text);
	}
}