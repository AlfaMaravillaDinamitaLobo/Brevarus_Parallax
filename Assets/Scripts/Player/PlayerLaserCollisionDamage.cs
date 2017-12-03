using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserCollisionDamage : MonoBehaviour
{
    public GameObject effect;
    public int damage;
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyCollisionDamage>().ReceiveDamage(damage);
            Die();
        }
		if(other.tag == "Boss")
		{
			other.GetComponent<MiniBossColisionDmg>().ReceiveDamage(damage);
			Die();
		}
    }

    void Die()
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
