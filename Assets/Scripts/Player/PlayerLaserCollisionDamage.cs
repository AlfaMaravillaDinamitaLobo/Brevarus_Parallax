using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserCollisionDamage : MonoBehaviour
{
	public GameObject player;
    public GameObject effect;
    public int damage;
 
    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy" || other.tag == "Boss")
        {
			player.GetComponent<RedShoot> ().addPower (2);
			other.SendMessage("ReceiveDamage",damage);
            Die();
        }
    }

    void Die()
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
