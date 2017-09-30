using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGreenMode : MonoBehaviour {

	public static Animator animacion;

	// Use this for initialization
	void Start () {
		animacion = GetComponent<Animator> ();
		animacion.SetBool ("redMode", true);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Alpha2) && animacion.GetBool ("redMode")) {
			animacion.SetBool ("greenMode", true);
			animacion.SetBool ("redMode", false);
		}

		if (Input.GetKey (KeyCode.Alpha1) && animacion.GetBool ("greenMode")) {
			animacion.SetBool ("redMode", true);
			animacion.SetBool ("greenMode", false);
		}
	}
}
