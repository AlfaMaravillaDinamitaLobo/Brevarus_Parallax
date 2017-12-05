using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {

    //private Transform parent;

	public string mode;
    
    void Start ()
    {
        //parent = this.transform.parent;

        mode = "Red";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == mode)
        {
            other.gameObject.GetComponent<CollisionDamage>().Die();
        }
    }

    public void ChangeMode()
    {
        if(mode == "Red")
        {
            mode = "Green";
        }
        else
        {
            mode = "Red";
        }
    }
}
