using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossColisionDmg : MonoBehaviour {

	public int health;
	public int maxHp;
	public float invulnPeriod = 0.2f;

	public GameObject healthBar;

	private bool damaged;
	private float invulnTimer = 0;
	private int correctLayer;


	void Start()
	{
		correctLayer = gameObject.layer;
		damaged = false;
		maxHp = health;
	}

	void Update()
	{
		invulnTimer -= Time.deltaTime;

		if (invulnTimer > 0)
			damaged = true;

		if(invulnTimer <= 0){
			gameObject.layer = correctLayer;
			damaged = false;
		}

		if (health <= 0)
			Die();
	}

    public void ReceiveDamage(int damage)
    {
		if (!damaged) {
			health = health - damage;
			invulnTimer = invulnPeriod;
			gameObject.layer = 10;
			GetComponent<Animator> ().Play ("OnHit");

			healthBar.GetComponent<EnemySetter>().SetEnemy(gameObject);

			GameObject bar= Instantiate(healthBar, 
				new Vector3(640f,-23.6f,Statics.UIProperties().getZPositionEnemyBar()),
				Quaternion.Euler(0,0,0));
			bar.transform.localScale = new Vector3 (1, 1, 1);
			bar.transform.SetParent (Statics.getUIGameObject());
		}
		invulnTimer = invulnPeriod;
		gameObject.layer = 10;
		GetComponent<Animator> ().Play("OnHit");
    }

	void Die()
	{
		Destroy(gameObject);
	}
}
