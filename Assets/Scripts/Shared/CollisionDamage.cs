using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour {

    public int health = 1;
    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;

    void Start()
    {
        correctLayer = gameObject.layer;
    }

    void OnTriggerEnter2D()
    {
		Physics2D.IgnoreLayerCollision (8, 13);
		Physics2D.IgnoreLayerCollision (13, 8);
		Physics2D.IgnoreLayerCollision (12, 12);
		Physics2D.IgnoreLayerCollision (13, 12);
		Physics2D.IgnoreLayerCollision (12, 13);
        Debug.Log("Activado el trigger");
        health--;
        invulnTimer = invulnPeriod;
        gameObject.layer = 10;
        
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
    void Die()
    {
        Destroy(gameObject);
    }
}
