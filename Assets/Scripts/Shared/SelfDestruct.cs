using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float destroyTime;

    void Update () {

        Destroy(gameObject, destroyTime);

    }
}
