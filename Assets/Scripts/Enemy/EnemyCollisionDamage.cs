using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDamage : MonoBehaviour {

    public int health;
    public GameObject effect;
    public GameObject powerUp;


    void OnTriggerEnter2D(Collider2D other)
    {
        health--;

    }

    void Update()
    {
       
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        int random = Random.Range(0, 10);
        if (random == 1)
        {
            Instantiate(powerUp, transform.position, transform.rotation);
        }
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
