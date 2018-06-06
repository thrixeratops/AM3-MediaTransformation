using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDistance : MonoBehaviour {

	public Camera MainCamera;
	public Canvas HudCanvas;

	void Start () {

	}
		
	void Update () {
		RaycastHit hit;
		Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			HudCanvas.planeDistance = Vector3.Distance (hit.point, transform.position);
		}
	}
}
