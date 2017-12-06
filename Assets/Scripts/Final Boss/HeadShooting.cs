using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShooting : MonoBehaviour {

	public ParticleSystem blueParticles;
	public ParticleSystem yellowParticles;
	public ParticleSystem redParticles;
	public GameObject beam;
	public int specialInterval;
	private int specialCounter;

	private AudioSource sound;

	void Start () {
		specialCounter = specialInterval;
		sound = this.GetComponent<AudioSource> ();
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
		sound.Play();
		Invoke ("BlueParticles", 0.0f);
		Invoke ("BlueParticles", 1.0f);
		Invoke ("YellowParticles", 2.0f);
		Invoke ("YellowParticles", 3.0f);
		Invoke ("RedParticles", 4.0f);
		Invoke ("RedParticles", 5.0f);
		Invoke ("Fire", 6.5f);
	}

	public void Fire(){
		Vector3 offset = new Vector3 (0f, -12f, 0f);
		Instantiate (beam, transform.position + offset, transform.rotation, transform);
	}

	public void BlueParticles(){
		Instantiate(blueParticles, transform);
	}

	public void YellowParticles(){
		Instantiate(yellowParticles, transform);
	}

	public void RedParticles(){
		Instantiate(redParticles, transform);
	}
}
