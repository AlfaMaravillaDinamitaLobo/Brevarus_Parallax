using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShoot : MonoBehaviour {

	public GameObject laserPrefab1;
	public GameObject laserPrefab2;
	public GameObject specialPrefab;
    public float fireDelay = 0.25f;

    private float cooldownTimer = 0;
	private GameObject specialShoot = null;

	void Update () {
        cooldownTimer -= Time.deltaTime;
		if(Input.GetButton("Fire1") && cooldownTimer <= 0)
        {

            Debug.Log("Disparo del jugador");
            cooldownTimer = fireDelay;

            Vector3 offset1 = transform.rotation * new Vector3(0.5f, 1f, 0);
            Vector3 offset2 = transform.rotation * new Vector3(-0.5f, 1f, 0);
            Instantiate(laserPrefab1, transform.position + offset1, transform.rotation);
            Instantiate(laserPrefab2, transform.position + offset2, transform.rotation);
        }

		if (Input.GetKey (KeyCode.LeftShift) && cooldownTimer <= 0/*La segunda condicion seria tener 100% deenergia cargada*/) {
			cooldownTimer = fireDelay;
			specialShoot = Instantiate(specialPrefab, transform.position, transform.rotation);

			specialShoot.transform.position = transform.position;
			Physics2D.IgnoreLayerCollision (8, 11);
		}
	}
}
