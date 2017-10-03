using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoos1Shooting : MonoBehaviour {

	public GameObject laserPrefab;
	public GameObject mbossBullet1;
	public GameObject mbossBullet2;
	public GameObject mbossBullet3;
	public GameObject mbossBullet4;
	public GameObject mbossBullet5;
	public GameObject mbossBullet6;

	private Vector3 bullet1Offset = new Vector3(0.125f, -1.7f, 0f);
	private Vector3 bullet2Offset = new Vector3(-0.125f, -1.7f, 0f);
	private Vector3 bullet3Offset = new Vector3(-0.25f, -1.7f, 0f);
	private Vector3 bullet4Offset = new Vector3(0.25f, -1.7f, 0f);
	private Vector3 bullet5Offset = new Vector3(0.5f, -1.5f, 0f);
	private Vector3 bullet6Offset = new Vector3(-0.5f, -1.5f, 0f);
		

	float laserCDTimer = 4f;
	float bulletCD = 1f;

	// Update is called once per frame
	void Update () {
		laserCDTimer -= Time.deltaTime;
		bulletCD -= Time.deltaTime;
		if (laserCDTimer <= 0) {
			laserCDTimer = 4f;
			Instantiate (laserPrefab, transform.position, transform.rotation);

			laserPrefab.transform.position = transform.position;
		}
		if (bulletCD <= 0) {
			bulletCD = 1f;

			Vector3 offset1 = transform.rotation * bullet1Offset;
			Vector3 offset2 = transform.rotation * bullet2Offset;
			Vector3 offset3 = transform.rotation * bullet3Offset;
			Vector3 offset4 = transform.rotation * bullet4Offset;
			Vector3 offset5 = transform.rotation * bullet5Offset;
			Vector3 offset6 = transform.rotation * bullet6Offset;

			Instantiate (mbossBullet1, transform.position + offset1, Quaternion.Euler(0f, 0f, 15f));
			Instantiate (mbossBullet2, transform.position + offset2, Quaternion.Euler(0f, 0f, -15f));
			Instantiate (mbossBullet3, transform.position + offset3, Quaternion.Euler(0f, 0f, -45f));
			Instantiate (mbossBullet4, transform.position + offset4, Quaternion.Euler (0f, 0f, 45f));
			Instantiate (mbossBullet5, transform.position + offset5, Quaternion.Euler(0f, 0f, 75f));
			Instantiate (mbossBullet6, transform.position + offset6, Quaternion.Euler(0f, 0f, -75f));

		}
	}
}
