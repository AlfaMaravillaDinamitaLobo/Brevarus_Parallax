using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour {

    public int health = 1;
    public float invulnPeriod = 0;
	public GameObject effect;
	public int damage;

    private float invulnTimer = 0;
	private int correctLayer;
	private bool alreadyHurt;


    void Start()
    {
		alreadyHurt = false;
        correctLayer = gameObject.layer;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag == "Player" && !alreadyHurt)
        {
			alreadyHurt = true;
			other.GetComponent<PlayerCollisionDamage>().ReceiveDamage(damage);
            health--;
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
        }
		if(other.tag == "Player shield" )
		{
			Die ();
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
