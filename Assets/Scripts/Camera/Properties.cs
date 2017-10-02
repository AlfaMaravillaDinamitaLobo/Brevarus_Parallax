using UnityEngine;
using System.Collections;

public class Properties
{
	public static float limitY()
	{
		return 10f;
	}

	public static float limitX()
	{
		return 14f;
	}

	public static bool gameObjectIsVisible(GameObject gameObject){
		Camera cam = Camera.main;
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
		Collider2D anObjCollider = gameObject.GetComponent<Collider2D>();

		return GeometryUtility.TestPlanesAABB (planes, anObjCollider.bounds);
	}
}


