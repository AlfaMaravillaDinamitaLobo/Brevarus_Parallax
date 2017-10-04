using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Transform camera;

	public GameObject lvl1Enemy1;
	public GameObject lvl1Enemy2;
	public GameObject lvl1Enemy3;
	public GameObject lvl1Enemy4;
	public GameObject lvl1Boss;

	public bool faltaOleada1 = true;
	public bool faltaOleada2 = true;
	public bool faltaOleada3 = true;
	public bool faltaOleada4 = true;
	public bool faltaBoss = true;

	private OleadasNivel1 nivel1;
	private float timer;

	// Use this for initialization
	void Start () {
		nivel1 = new OleadasNivel1 (lvl1Enemy1,lvl1Enemy2,lvl1Enemy3,lvl1Enemy4,lvl1Boss);
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= 5f && faltaOleada1) {
			nivel1.primerOleada (camera);
			faltaOleada1 = false;
		}

		if (timer >= 20f && faltaOleada2) {
			nivel1.segundaOleada (camera);
			faltaOleada2 = false;
		}

		if (timer >= 30f && faltaOleada3) {
			nivel1.tercerOleada (camera);
			faltaOleada3 = false;
		}

		if (timer >= 60f && faltaBoss) {
			nivel1.spawnBoss (camera);
			faltaBoss = false;
		}

		Debug.Log (timer);
	}
}
