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
	private float cooldownTimer;
	public float changeDelay;
    AudioSource sound;
    
   
	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
        cooldownTimer = 0f;
		parent = this.transform.parent.gameObject;
        
		animacion = this.transform.parent.GetComponent<Animator> ();
		animacion.SetBool ("redMode", true);
	}
	
	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;

		if (enabledChange()) {
			if (Input.GetKey (KeyCode.Alpha2) && animacion.GetBool ("redMode")) {
				animacion.SetBool ("greenMode", true);
				animacion.SetBool ("redMode", false);
				cooldownTimer = changeDelay;
                sound.Play();

            }

			if (Input.GetKey (KeyCode.Alpha1) && animacion.GetBool ("greenMode")) {
				animacion.SetBool ("redMode", true);
				animacion.SetBool ("greenMode", false);
				cooldownTimer = changeDelay;
                sound.Play();
            }

			parent.GetComponent<RedShoot> ().enabled = animacion.GetBool ("redMode");
			parent.GetComponent<GreenShoot> ().enabled = animacion.GetBool ("greenMode");
		}
	}

	bool enabledChange(){
		//Debug.Log (cooldownTimer);
		return cooldownTimer <= 0f;
	}
}