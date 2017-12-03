using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogSpawner : MonoBehaviour {

	public Transform camara;
	public GameObject fog;
	public float spawn;

	private float timer;
	private float orientacion;

	void Start () {
		timer = 0f;
		orientacion = 1f;
	}

	void Update () {
		timer += Time.deltaTime;

		if (timer >= spawn) {
			float y = Statics.limitY ();
			GameObject aFog = Instantiate(fog, new Vector3((Statics.limitX() + 15f) * orientacion, y - Random.Range(0, y*2), 0.5f), camara.rotation);
			if(aFog.transform.position.x < 0f)
				aFog.GetComponent<FogMovement>().maxSpeed *= (-1);

			timer = 0f;

			orientacion *= -1;
		}
	}

}
