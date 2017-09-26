using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Este script es para gestionar todos los modos de juego del jugador...
	Los modos actuales estan en greenMode y redMode pero pueden cambiar.

	Para agregar o cambiar modos:
		- Agregar animacion al player.
		- Agregar lo necesario en los if del update y en un nuevo if, si se agrega otro modo.
		- Habilitar o deshabilitar los nuevos script (debajo de los if del update)
		- Agregar un Script con el nuevo modo de disparo al player.
*/
public class ModeManager : MonoBehaviour {

	private Animator animacion;
	private GameObject parent;

	// Use this for initialization
	void Start () {
		parent = this.transform.parent.gameObject;

		animacion = this.transform.parent.GetComponent<Animator> ();
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

		parent.GetComponent<RedShoot> ().enabled = animacion.GetBool ("redMode");
		parent.GetComponent<GreenShoot> ().enabled = animacion.GetBool ("greenMode");
	}
}