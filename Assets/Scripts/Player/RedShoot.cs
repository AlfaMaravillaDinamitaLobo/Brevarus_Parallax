using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShoot : MonoBehaviour {

    public GameObject laserPrefab1;
    public GameObject laserPrefab2;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

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
	}
}
