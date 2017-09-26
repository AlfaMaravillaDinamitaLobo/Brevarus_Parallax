using UnityEngine;
using System.Collections;

public class ShieldDestruct : MonoBehaviour
{

	public float timerNormal;
	public float timerSpecial;
	private Animator animacion;

	void Start () {
		animacion = GetComponent<Animator> ();
	}

	void Update () {
		timerNormal -= Time.deltaTime;
		timerSpecial -= Time.deltaTime;

		if(timerNormal <= 0 || (timerSpecial <= 0 && animacion.GetBool ("greenSpecial")))
			Destroy(gameObject);
	}
}

