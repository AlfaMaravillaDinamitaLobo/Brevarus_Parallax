using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryRelator : MonoBehaviour {

	private float counter;
	private bool alertSpawned;
	private HistoryLevel1 history;
	private int currentHistory;

	public GameObject historyPrefab;
	public GameObject alert;

	void Start(){
		history = new HistoryLevel1 ();
		alertSpawned = false;
		counter = 0f;
		currentHistory = 0;
	}

	void Update () {
		counter += Time.deltaTime;

		if (counter >= 54f && !alertSpawned) {
			Instantiate (alert, new Vector2 (0f,0f), Quaternion.Euler(new Vector3(0f,0f,30f)));

			alertSpawned = true;
		}

		if (counter >= 0f && currentHistory == 0) {
			GameObject aHistory = Instantiate (historyPrefab, new Vector2 (Statics.limitX() - 23.65f, 0f), transform.rotation);

			aHistory.SendMessage("SetText", history.getHistoryN (currentHistory));
			currentHistory++;
		}

		if (counter >= 55f && currentHistory == 1) {
			GameObject aHistory = Instantiate (historyPrefab, new Vector2 (Statics.limitX() - 23.55f, 0f), transform.rotation);

			aHistory.SendMessage("SetText", history.getHistoryN (currentHistory));
			currentHistory++;
		}

		if (counter >= 75f && currentHistory == 2) {
			GameObject aHistory = Instantiate (historyPrefab, new Vector2 (Statics.limitX() - 23.55f, 0f), transform.rotation);

			aHistory.SendMessage("SetText", history.getHistoryN (currentHistory));
			currentHistory++;
		}
	}
}
