using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyCollisionDamage>().ReceiveDamage(2);
            Die();
        }
        if (other.tag == "Boss")
        {
            other.GetComponent<MiniBossColisionDmg>().ReceiveDamage(2);
            Die();
        }
    }

    public void Die()
    {
        //Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
