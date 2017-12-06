using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HistoryRelator : MonoBehaviour {

	private HistoryLevel1 history;
	private EnemySpawner enemySpawner;
	private bool introSpawn;
	private bool finalSpawn;
	private bool finalLevel;

	public int currentHistory;
	public bool alertSpawned;

	public GameObject historyPrefab;
	public GameObject alert;
	public GameObject introScreen;
	public GameObject finalScreen;

	public GameObject gui1;
	public GameObject gui2;

	public GameObject player1;
	public GameObject player2;

	public int jumpLevel;

	void Start(){
		introSpawn = false;
		finalSpawn = false;
		history = new HistoryLevel1 ();
		enemySpawner = GetComponent<EnemySpawner> ();
		alertSpawned = false;
		currentHistory = 0;
		jumpLevel = 0;
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

		if (!enemySpawner.faltaOleada3 && Statics.NoHayEnemigos() && !alertSpawned) {
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
			jumpLevel++;
		}

		if (jumpLevel > 50) {
			//gui1 = GameObject.Find ("GuiPlayer1");
			//gui2 = GameObject.Find ("GuiPlayer2");
			PlayerPrefs.SetInt ("Player1Lifes", gui1.GetComponent<StatsPlayer> ().lifes);
			PlayerPrefs.SetInt ("Player2Lifes", gui2.GetComponent<StatsPlayer> ().lifes);
			PlayerPrefs.SetFloat ("Player1Score", gui1.GetComponent<StatsPlayer> ().score);
			PlayerPrefs.SetFloat ("Player2Score", gui2.GetComponent<StatsPlayer> ().score);
			SceneManager.LoadScene (2);
		}

		if (player1 == null && player2 == null) {
			SceneManager.LoadScene (0);
		}
	}
}
