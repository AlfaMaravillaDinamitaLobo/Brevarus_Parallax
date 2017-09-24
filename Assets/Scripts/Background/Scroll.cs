using System.Collections;
using UnityEngine;

public class Scroll : MonoBehaviour {

	public float velocidad = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (0, Time.time * velocidad);
	}
}
