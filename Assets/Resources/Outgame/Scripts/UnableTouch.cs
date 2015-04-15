using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnableTouch :  Button, ICanvasRaycastFilter{
	
	[SerializeField]
	float radius = 0f;
	
	public bool IsRaycastLocationValid (Vector2 sp, Camera eventCamera)
	{
		return Vector2.Distance(sp, transform.position) < radius;
	}
}