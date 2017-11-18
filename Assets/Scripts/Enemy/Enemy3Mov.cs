using UnityEngine;
using System.Collections;

public class Enemy3Mov : MonoBehaviour
{
	private bool playerOnTheRight;
	public float velocidadMovimiento;

	// Use this for initialization
	void Start ()
	{
		GameObject obj = GameObject.Find("Ship");

		if(obj != null)
		{
			float distX = obj.transform.position.x - transform.position.x;
			playerOnTheRight = distX <= 0;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(playerOnTheRight)
			transform.position -= Vector3.right * velocidadMovimiento * Time.deltaTime;
		else
			transform.position += Vector3.right * velocidadMovimiento * Time.deltaTime;
	}
}

