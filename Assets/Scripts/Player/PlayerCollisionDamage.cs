using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDamage : MonoBehaviour {

    public int health = 12;
    public float invulnPeriod = 1;
    float invulnTimer = 0;
    int correctLayer;
    public GameObject effect;

    void Start()
    {
        correctLayer = gameObject.layer;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
		
        health--;
        invulnTimer = invulnPeriod;
        gameObject.layer = LayerMask.NameToLayer("Invulnerable");

    }

    void Update()
    {
        invulnTimer -= Time.deltaTime;
        if (invulnTimer <= 0)
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
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

	public void Recover()
	{
		health = Mathf.Min(health + 6, 12);
	}
}
