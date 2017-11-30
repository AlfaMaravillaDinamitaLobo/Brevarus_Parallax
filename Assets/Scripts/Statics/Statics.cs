using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statics{
	public static float limitY()
	{
		return 10f;
	}

	public static float limitX()
	{
		return 14f;
	}

	public static Transform TransformOfChildByName(Transform aGameObject, string name){
		return aGameObject.transform.Find (name);
	}

	public static bool gameObjectIsVisible(GameObject gameObject){
		Camera cam = Camera.main;
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
		Collider2D anObjCollider = gameObject.GetComponent<Collider2D>();

		return GeometryUtility.TestPlanesAABB (planes, anObjCollider.bounds);
	}

	public static Transform getUIGameObject(){
		return GameObject.Find ("UIGameObject").transform;
	}

	public static UIProperties UIProperties(){
		return GameObject.Find ("UIGameObject").GetComponent<UIProperties>();
	}

	public static GameObject FindPlayerOne(){

		return GameObject.Find("Ship");
	}
}

