using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryRelatorNivel2 : MonoBehaviour {

	private HistoryLevel2 history;
	private EnemySpawnerNivel2 enemySpawner;
	private bool introSpawn;
	private bool finalSpawn;
	private bool finalLevel;

	public int currentHistory;
	public bool alertSpawned;

	public GameObject historyPrefab;
	public GameObject alert;
	public GameObject introScreen;
	public GameObject finalScreen;

	private GameObject gui1;
	private GameObject gui2;

	void Start(){
		gui1 = GameObject.Find ("GuiPlayer1");
		gui2 = GameObject.Find ("GuiPlayer2");

		gui1.GetComponent<StatsPlayer>().score = PlayerPrefs.GetFloat ("Player1Score", 0f);
		gui2.GetComponent<StatsPlayer>().score = PlayerPrefs.GetFloat ("Player2Score", 0f);
		gui1.GetComponent<StatsPlayer>().lifes = PlayerPrefs.GetInt ("Player1Lifes", 3);
		gui2.GetComponent<StatsPlayer>().lifes = PlayerPrefs.GetInt ("Player2Lifes", 3);

		introSpawn = false;
		finalSpawn = false;
		history = new HistoryLevel2 ();
		enemySpawner = GetComponent<EnemySpawnerNivel2> ();
		alertSpawned = false;
		currentHistory = 0;
	}

	void Update () {

		if (Time.time >= 0 && !introSpawn) {
			Instantiate (introScreen, new Vector2(0f,0f), transform.rotation);
			introSpawn = true;
		}

		if (Time.time >= 2 && currentHistory == 0) {
			GameObject aHistory = Instantiate (historyPrefab, new Vector2 (Statics.limitX() - 23.65f, 0f), transform.rotation);

			aHistory.SendMessage("SetText", history.getHistoryN (currentHistory));
			currentHistory++;
		}

		if (!enemySpawner.faltaOleada2 && currentHistory == 1 && Statics.NoHayEnemigos()) {
			GameObject aHistory = Instantiate (historyPrefab, new Vector2 (Statics.limitX() - 23.55f, 0f), transform.rotation);

			aHistory.SendMessage("SetText", history.getHistoryN (currentHistory));
			currentHistory++;
		}

		if (!enemySpawner.faltaOleada4 && Statics.NoHayEnemigos() && !alertSpawned) {
			Instantiate (alert, new Vector2 (0f,0f), Quaternion.Euler(new Vector3(0f,0f,30f)));

			alertSpawned = true;
		}

		if (!enemySpawner.faltaBoss && Statics.NoHayEnemigos() && currentHistory == 2) {
			GameObject aHistory = Instantiate (historyPrefab, new Vector2 (Statics.limitX() - 23.55f, 0f), transform.rotation);

			aHistory.SendMessage("SetText", history.getHistoryN (currentHistory));
			currentHistory++;
		}

		if (!finalSpawn && currentHistory == 3 && Statics.NoHayHistorias()) {
			Instantiate (finalScreen, new Vector2(0f,0f), transform.rotation);
			finalLevel = true;
			introSpawn = true;
		}

		if (finalLevel) {
			GetComponent<AudioSource> ().volume -= Time.deltaTime;
		}
	}
}
