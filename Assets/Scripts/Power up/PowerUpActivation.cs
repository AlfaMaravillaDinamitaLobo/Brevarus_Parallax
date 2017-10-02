using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActivation : MonoBehaviour {

    public GameObject effect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        

    }
}
