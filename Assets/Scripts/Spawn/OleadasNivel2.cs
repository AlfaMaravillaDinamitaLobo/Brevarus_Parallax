using UnityEngine;
using System.Collections;

public class OleadasNivel2 : MonoBehaviour
{
	private GameObject enemy1;
	private GameObject enemy2;
	private GameObject enemy3;
	private GameObject enemy4;
	private GameObject boss;

	public OleadasNivel2(GameObject enemy1Prefab, GameObject enemy2Prefab, GameObject enemy3Prefab, GameObject enemy4Prefab, GameObject boss){
		enemy1 = enemy1Prefab;
		enemy2 = enemy2Prefab;
		enemy3 = enemy3Prefab;
		enemy4 = enemy4Prefab;
		this.boss = boss;
	}

	public void primerOleada (Transform camera){
		float initY = Statics.limitY () - 23f;
		float distance = 3f;
		for (int y = 0; y < 60; y+=3) {
			Instantiate (enemy3, new Vector3(distance,initY - y,2.9f),camera.rotation);
			distance *= -1;
		}

		/*Se le suma 2.9 para que los enemigos aparescan por encima de la posicion de la camara, y para que
			esta sea 0 se le suma 2.9
		*/
	}

	public void segundaOleada (Transform camera){
		float initY = Statics.limitY () + 3f;
		for (int y = 0; y < 330; y+=3) {
			Instantiate (enemy4, new Vector3(Random.Range(-Statics.limitX(),Statics.limitY()),initY+y,2.9f),flip(camera.rotation));
		}

		/*Se le suma 2.9 para que los enemigos aparescan por encima de la posicion de la camara, y para que  esta sea 0 se le suma 2.9
		*/
	}

	public void tercerOleada (Transform camera){
		Instantiate(enemy1, camera.position + new Vector3(Properties.limitX()-2f,Properties.limitY()-2f,2.9f),flip(camera.rotation));
		Instantiate(enemy1, camera.position + new Vector3(-Properties.limitX()+2f,Properties.limitY()-2f,2.9f),flip(camera.rotation));

		float addY = 0f;
		for (float y = 0f; y < 5f; y += 4) {
			Instantiate (enemy2, camera.position + new Vector3 (Properties.limitX(), y , 2.9f),camera.rotation);
			Instantiate (enemy2, camera.position + new Vector3 (-Properties.limitX(), y , 2.9f),camera.rotation);
		}

		/*Se le suma 2.9 para que los enemigos aparescan por encima de la posicion de la camara, y para que
			esta sea 0 se le suma 2.9
		*/
	}

	public void cuartaOleada (Transform camera){
		primerOleada (camera);
		segundaOleada (camera);

		/*Se le suma 2.9 para que los enemigos aparescan por encima de la posicion de la camara, y para que  esta sea 0 se le suma 2.9
		*/
	}

	public void spawnBoss (Transform camera){
		Instantiate (boss, camera.position + new Vector3 (0, Statics.limitY()+8f, 2.9f),flip(camera.rotation));

		/*Se le suma 2.9 para que los enemigos aparescan por encima de la posicion de la camara, y para que
			esta sea 0 se le suma 2.9
		*/
	}

	private Quaternion flip(Quaternion rotation){
		return rotation * Quaternion.Euler (0f, 0f, 180f);
	}
}

