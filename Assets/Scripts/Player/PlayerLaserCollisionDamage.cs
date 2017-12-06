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
		if(other.tag == "Enemy")
        {
			if (player != null) 
				player.SendMessage ("AddPower", 2);
			
			other.SendMessage("ReceiveDamage",damage);

			if (other.tag == "Enemy" && other.GetComponent<EnemyCollisionDamage>().health <= 0f)
				player.SendMessage ("AddScore", other.GetComponent<StatsEnemy> ().deathPoint);

			if (other.tag == "MiniBoss" && other.GetComponent<MiniBossColisionDmg>().health <= 0f)
				player.SendMessage ("AddScore", other.GetComponent<StatsEnemy> ().deathPoint);

			if (other.tag == "Boss" && other.GetComponent<BossCollisionDamage>().health <= 0f)
				player.SendMessage ("AddScore", other.GetComponent<StatsEnemy> ().deathPoint);

			Die();
        }
		if(other.tag == "MiniBoss")
		{
			other.GetComponent<MiniBossColisionDmg>().ReceiveDamage(damage);
			Die();
		}

		if(other.tag == "Boss")
		{
			other.GetComponent<BossCollisionDamage>().ReceiveDamage(damage);
			Die();
		}
    }

    void Die()
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
