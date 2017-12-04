using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specials : MonoBehaviour {

	public void ActivateBonus(string tag)
	{
		if(tag == "Bullet")
		{
			//gameObject.GetComponent<RedShoot>().SpecialFire();
		}
		if(tag == "Life")
		{
			gameObject.GetComponent<PlayerCollisionDamage>().ExtraLife();
		}
		if(tag == "Health")
		{
			gameObject.GetComponent<PlayerCollisionDamage>().Recover();
		}
		if(tag == "Shield")
		{

		}
	}
}