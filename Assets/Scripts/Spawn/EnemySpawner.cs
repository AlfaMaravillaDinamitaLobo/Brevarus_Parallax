using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Transform camera;

	public GameObject lvl1Enemy1;
	public GameObject lvl1Enemy2;
	public bool faltaOleada1 = true;
	public bool faltaOleada2 = true;

	private OleadasNivel1 nivel1;
	private float timer;

	// Use this for initialization
	void Start () {
		nivel1 = new OleadasNivel1 (lvl1Enemy1,lvl1Enemy2);
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= 5f && faltaOleada1) {
			nivel1.primerOleada (camera);
			faltaOleada1 = false;
		}

		if (timer >= 15f && faltaOleada2) {
			nivel1.segundaOleada (camera);
			faltaOleada2 = false;
		}
	}
}
