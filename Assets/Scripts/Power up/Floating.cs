using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour {

    float movX;
    float movY;
    public float moveSpeed; 

    // Use this for initialization
    void Start () {
        movX = Random.Range(-1.0f, 1.0f);
        movY = Random.Range(-1.0f, 1.0f);

    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector3(movX, movY, 0) * moveSpeed * Time.deltaTime);

    }
}
