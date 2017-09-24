using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float maxSpeed = 5f;

    void Update()
    {
        Vector3 posY = transform.position;
        Vector3 velocityY = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        posY += transform.rotation * velocityY;
        transform.position = posY;

    }
}


