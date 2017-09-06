using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {

    float rotSpeed = 90f;
    Transform player;

	void Update () {
		if(player == null)
        {
            GameObject obj = GameObject.Find("Player");

            if(obj != null)
            {
                player = obj.transform;
            }
        }

        if(player == null)
        {
            return; 
        }

        Vector3 dir = player.position - transform.position;
        //Este vector indica la distancia a la que está player

        dir.Normalize();
        //Si antes dir era (-10, 0, 0), lo transforma en (-1, 0, 0)

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRotation = Quaternion.Euler(0, 0, zAngle);
        float allowedRotation = rotSpeed * Time.deltaTime;
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, allowedRotation);
    }
}
