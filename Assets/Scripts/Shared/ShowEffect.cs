using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEffect : MonoBehaviour {

    public GameObject effectPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Instantiate(effectPrefab, transform.position, transform.rotation);
        }
        

    }
}
