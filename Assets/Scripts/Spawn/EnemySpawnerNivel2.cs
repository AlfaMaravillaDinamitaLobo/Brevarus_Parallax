using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerNivel2 : MonoBehaviour {

	public Transform camera;

	public GameObject lvl2Enemy1;
	public GameObject lvl2Enemy2;
	public GameObject lvl2Enemy3;
	public GameObject lvl2Enemy4;
	public GameObject lvl2Boss;

	public bool faltaOleada1 = true;
	public bool faltaOleada2 = true;
	public bool faltaOleada3 = true;
	public bool faltaOleada4 = true;
	public bool faltaBoss = true;

	private OleadasNivel2 nivel2;
	private HistoryRelatorNivel2 historyRelator;
	private float timer;

	// Use this for initialization
	void Start () {
		historyRelator = GetComponent<HistoryRelatorNivel2> ();
		nivel2 = new OleadasNivel2 (lvl2Enemy1,lvl2Enemy2,lvl2Enemy3,lvl2Enemy4,lvl2Boss);
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= 11f && faltaOleada1) {
			nivel2.primerOleada (camera);
			faltaOleada1 = false;
			timer = 0;
		}

		if (faltaOleada2 && !faltaOleada1 && ( EsHoraOleada(Statics.TimePerWave()) || Statics.NoHayEnemigos() )) {
			nivel2.segundaOleada (camera);
			faltaOleada2 = false;
			timer = 0;
		}

		if (faltaOleada3 && !faltaOleada2 && Statics.NoHayHistorias() && historyRelator.currentHistory == 2) {
			nivel2.tercerOleada (camera);
			faltaOleada3 = false;
			timer = 0;
		}

		if (faltaOleada4 && !faltaOleada3 && ( EsHoraOleada(Statics.TimePerWave()) || Statics.NoHayEnemigos() )) {
			nivel2.cuartaOleada (camera);
			faltaOleada4 = false;
			timer = 0;
		}

		if (historyRelator.alertSpawned && faltaBoss && Statics.NoHayHistorias()) {
			nivel2.spawnBoss (camera);
			faltaBoss = false;
			timer = 0;
		}

		//Debug.Log (Time.time);
	}

	private bool EsHoraOleada(float time){
		return timer >= time;
	}
}
