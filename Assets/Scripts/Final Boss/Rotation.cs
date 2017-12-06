using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	public GameObject pivot;
	private Vector3 point;
	public Vector3 axis;
	public float rotationAngle;
	private float counter;
	public float speed;

	// Use this for initialization
	void Start () {
		point = pivot.transform.position;
		//axis = new Vector3 (0f, 0f, 1f);
		counter = rotationAngle;
	}
	
	// Update is called once per frame
	void Update () {
		point = pivot.transform.position;
		counter--;
		if (counter <= 0) {
			counter = rotationAngle;
			axis = new Vector3 (axis.x, axis.y, -axis.z);
		}
		transform.RotateAround(point, axis, speed * Time.deltaTime);
		
	}
}
