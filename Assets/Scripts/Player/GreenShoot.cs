using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenShoot : MonoBehaviour {

    public GameObject shieldPrefab;
	public float defenseDelay;

	private float cooldownTimer = 0;
	private GameObject shield = null;
	public string botonDeDisparo1 = "Fire1";
	public string botonDeDisparo2 = "Fire2";


    void Update () {
		cooldownTimer -= Time.deltaTime;

		if(Input.GetButton(botonDeDisparo1) && cooldownTimer <= 0){
			cooldownTimer = defenseDelay;
			shield = Instantiate(shieldPrefab, transform.position, transform.rotation);
            Animator animacion = shield.GetComponent<Animator> ();
			animacion.SetBool ("greenNormal", true);
			animacion.SetBool ("greenSpecial", false);
//			destroyShield (shield);
		}

		if (Input.GetButton (botonDeDisparo2) && cooldownTimer <= 0/*La segunda condicion seria tener 100% deenergia cargada*/) {
			cooldownTimer = defenseDelay;
			shield = Instantiate(shieldPrefab, transform.position, transform.rotation);

			Animator animacion = shield.GetComponent<Animator> ();
			animacion.SetBool ("greenNormal", false);
			animacion.SetBool ("greenSpecial", true);
//			destroyShield (shield);
		}

		if (shield != null)
			shield.transform.position = transform.position;
	}

	void destroyShield(GameObject shield){
		if (GetComponent<Animator> ().GetBool ("redMode"))
			Debug.Log (GetComponent<Animator> ().GetBool ("redMode"));
			Destroy (shield);
	}
}
