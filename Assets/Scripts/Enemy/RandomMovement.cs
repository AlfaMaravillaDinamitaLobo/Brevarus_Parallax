using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

    float maxX = 13f;
    float minX = -13f;
    float maxY = 7f;
    float minY = -7f;
    bool llegoAlFinalX;
    bool llegoAlFinalY;

	private float counter;
    private float tChange = 0; 
    private float randomX;
    private float randomY;
    public float moveSpeed = 2f;
     
    void Update()
    {
		counter += Time.deltaTime;
		if (counter >= Statics.TimePerWave ()) {
			GetComponent<FrontMovement> ().enabled = true;
			GetComponent<FrontMovement> ().maxSpeed = 15f;
			Destroy (gameObject, 2);

			GetComponent<RandomMovement> ().enabled = false;
		}

        ControlarBordesX();
        ControlarBordesY();
        if (Time.time >= tChange)
        {
            randomX = Random.Range(-2.0f, 2.0f); 
            randomY = Random.Range(-2.0f, 2.0f); 
                                              
            tChange = Time.time + Random.Range(0.5f, 1.5f);
        }
        transform.Translate(new Vector3(randomX, randomY, 0) * moveSpeed * Time.deltaTime);
        
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            randomX = -randomX;
        }
        if (transform.position.y >= maxY || transform.position.y <= minY)
        {
            randomY = -randomY;
        }

        transform.Rotate(0, 0, 20 * Time.deltaTime);
    }

    void ControlarBordesX()
    {
        if (llegoAlFinalX)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
        }

        if (transform.position.x >= 13f)
        {
            llegoAlFinalX = false;
        }

        if (transform.position.x <= -13f)
        {
            llegoAlFinalX = true;
        }

    }

    void ControlarBordesY()
    {
        if (llegoAlFinalY)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.up * moveSpeed * Time.deltaTime;
        }

        if (transform.position.y >= 7f)
        {
            llegoAlFinalY = false;
        }

        if (transform.position.y <= -7f)
        {
            llegoAlFinalY = true;
        }

    }
}
