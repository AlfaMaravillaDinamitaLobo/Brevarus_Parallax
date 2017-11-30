using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiPlayer : MonoBehaviour {

	public GameObject guiPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddScore(int score){
		guiPlayer.SendMessage ("AddScore", score);
	}
}
