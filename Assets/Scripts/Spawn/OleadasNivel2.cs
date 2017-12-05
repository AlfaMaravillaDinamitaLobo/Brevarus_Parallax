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
		boss = boss;
	}

	public void primerOleada (Transform camera){

		for (int x = 0; x < 10; x++) {
			Instantiate (enemy1, new Vector3(0f,0f,2.9f),camera.rotation);
		}

		/*Se le suma 2.9 para que los enemigos aparescan por encima de la posicion de la camara, y para que
			esta sea 0 se le suma 2.9
		*/
	}

	public void segundaOleada (Transform camera){
		float currentRotation = 0f;

		Instantiate(enemy1, camera.position + new Vector3(0f,						-Properties.limitY() -11f,	2.9f), angleRotation(ref currentRotation));
		Instantiate(enemy1, camera.position + new Vector3(Properties.limitX() +4f,	-Properties.limitY() -4f,	2.9f), angleRotation(ref currentRotation));
		Instantiate(enemy1, camera.position + new Vector3(Properties.limitX() +7f,	0,							2.9f), angleRotation(ref currentRotation));
		Instantiate(enemy1, camera.position + new Vector3(Properties.limitX() +4f,	Properties.limitY() +4f,	2.9f), angleRotation(ref currentRotation));
		Instantiate(enemy1, camera.position + new Vector3(0f,						Properties.limitY() +11f,	2.9f), angleRotation(ref currentRotation));
		Instantiate(enemy1, camera.position + new Vector3(-Properties.limitX() -4f,	Properties.limitY() +4f,	2.9f), angleRotation(ref currentRotation));
		Instantiate(enemy1, camera.position + new Vector3(-Properties.limitX() -7f, 0f,							2.9f), angleRotation(ref currentRotation));
		Instantiate(enemy1, camera.position + new Vector3(-Properties.limitX() -4f,	-Properties.limitY() -4f,	2.9f), angleRotation(ref currentRotation));

		/*Se le suma 2.9 para que los enemigos aparescan por encima de la posicion de la camara, y para que
			esta sea 0 se le suma 2.9
		*/
	}

	private Quaternion angleRotation(ref float currentRotation){
		Quaternion angle = Quaternion.Euler (0f, 0f, currentRotation);
		currentRotation += 45;

		return angle;
	}

	public void tercerOleada (Transform camera){
		Instantiate(enemy2, camera.position + new Vector3(Properties.limitX()-2f,Properties.limitY()-2f,2.9f),flip(camera.rotation));
		Instantiate(enemy2, camera.position + new Vector3(-Properties.limitX()+2f,Properties.limitY()-2f,2.9f),flip(camera.rotation));

		float addY = 0f;
		for (float y = 0f; y < 5f; y += 4) {
			Instantiate (enemy4, camera.position + new Vector3 (Properties.limitX(), y , 2.9f),camera.rotation);
			Instantiate (enemy4, camera.position + new Vector3 (-Properties.limitX(), y , 2.9f),camera.rotation);
		}

		/*Se le suma 2.9 para que los enemigos aparescan por encima de la posicion de la camara, y para que
			esta sea 0 se le suma 2.9
		*/
	}

	private Quaternion flip(Quaternion rotation){
		return rotation * Quaternion.Euler (0f, 0f, 180f);
	}

	public void spawnBoss (Transform camera)
	{
		Instantiate (boss, camera.position + new Vector3 (0, Properties.limitY()-1f, 2.9f),camera.rotation);

		/*Se le suma 2.9 para que los enemigos aparescan por encima de la posicion de la camara, y para que
			esta sea 0 se le suma 2.9
		*/
	}
}

