using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour {

	float rotateSpeed = 180;
	private Vector3 screenPoint;
	private Vector3 offset;
	private Transform ObjectTransform;


	void Start() {

	}

	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag() {

		if (Input.GetButton ("Fire3")) {
			if (Input.GetButton ("Fire1")) {
				float rotateY = Input.GetAxis ("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;;
				transform.Rotate (Vector3.right, rotateY);
			}
		}
		if (Input.GetButton ("Jump")) {
			
			if (Input.GetButton ("Fire1")) {
				float rotateZ = Input.GetAxis ("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
				transform.Rotate (Vector3.forward, -rotateZ);
			}
		} else if (!Input.GetButton ("Fire3") && !Input.GetButton ("Jump")) {

			Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
			transform.position = cursorPosition;
		}
	}


}