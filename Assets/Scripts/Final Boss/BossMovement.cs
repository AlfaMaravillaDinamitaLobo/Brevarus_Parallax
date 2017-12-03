using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

	public float yPosition;
	public float finalPosition;

	public float speed = 3f;
	bool endPoint;
	private Vector3 rightLimit;
	private Vector3 leftLimit;


	void Start () {
		yPosition = transform.position.y;
		finalPosition = 8.6f;

		rightLimit = transform.position + new Vector3(8, 0, 0);
		leftLimit = transform.position - new Vector3(8, 0, 0);
	}
	

	void Update () {
		EnterScreen ();
		SideMovement ();
	}

	void EnterScreen ()
	{
		yPosition = transform.position.y;
		if (yPosition > finalPosition) {
			Vector3 newYPosition = new Vector3 (transform.position.x, transform.position.y - 0.05f, transform.position.z);
			transform.position = newYPosition;
		} else {
			NotifyParts ();
		}
	}

	void SideMovement ()
	{
		if (yPosition < finalPosition) {
			if (endPoint)
			{
				transform.position += Vector3.right * speed * Time.deltaTime;
			}
			else
			{
				transform.position -= Vector3.right * speed * Time.deltaTime;
			}

			if (transform.position.x >= rightLimit.x)
			{
				endPoint = false;
			}
			if (transform.position.x <= leftLimit.x)
			{
				endPoint = true;
			}
		}
	}

	public void Faster(){
		speed = speed + 3;
		this.gameObject.GetComponent<BossCollisionDamage> ().PartDestroyed ();
	}

	public void NotifyParts (){
		ClawShooting[] partsList = this.gameObject.GetComponentsInChildren<ClawShooting>();
		foreach (ClawShooting script in partsList)
		{
			script.StartFiring ();  
		}
	}


}
