using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour {

    public int health = 1;
    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;
    public GameObject effect;

    void Start()
    {
        correctLayer = gameObject.layer;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerCollisionDamage>().ReceiveDamage(1);
            health--;
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
        }
    }

    void Update()
    {
        invulnTimer -= Time.deltaTime;
        if(invulnTimer <= 0)
        {
            gameObject.layer = correctLayer;
        }
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
