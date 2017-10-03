using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Shooting : MonoBehaviour {

    public Vector3 bulletOffset1 = new Vector3(1.45f, 1.75f, 0);
    public Vector3 bulletOffset2 = new Vector3(-1.45f, 1.75f, 0);
    //public Vector3 bulletOffset3 = new Vector3(1.45f, -1.75f, 0);
    //public Vector3 bulletOffset4 = new Vector3(-1.45f, -1.75f, 0);

    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    //public GameObject bulletPrefab3;
    //public GameObject bulletPrefab4;

    public float fireDelay = 0.90f;
    float cooldownTimer = 0;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;

            Vector3 offset1 = transform.rotation * bulletOffset1;
            Vector3 offset2 = transform.rotation * bulletOffset2;
            //Vector3 offset3 = transform.rotation * bulletOffset3;
            //Vector3 offset4 = transform.rotation * bulletOffset4;

            Instantiate(bulletPrefab1, transform.position + offset1, transform.rotation);
            Instantiate(bulletPrefab2, transform.position + offset2, transform.rotation);
            //Instantiate(bulletPrefab3, transform.position + offset3, transform.rotation);
            //Instantiate(bulletPrefab4, transform.position + offset4, transform.rotation);

        }
    }
}
