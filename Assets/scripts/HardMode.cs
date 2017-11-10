using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMode : MonoBehaviour {

	float rotateSpeed = 180;
	private Vector3 screenPoint;
	private Vector3 offset;
	private Transform ObjectTransform;

	public bool AlignedRotation = false;
	public bool AlignedPosition = false;

	public GameObject FirstObject;


	void Start() {

	}

	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag() {

		AlignedRotation = FirstObject.GetComponent<FirstObjectAlignment> ().AlignedRotation;
		AlignedPosition = FirstObject.GetComponent<FirstObjectAlignment> ().AlignedPos;

		if (Input.GetButton ("Fire3") && AlignedRotation == false) {
			if (Input.GetButton ("Fire1")) {
				float rotateY = Input.GetAxis ("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;;
				transform.Rotate (Vector3.right, rotateY);
			}
		}
		if (Input.GetButton ("Jump") && AlignedRotation == false) {

			if (Input.GetButton ("Fire1")) {
				float rotateZ = Input.GetAxis ("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
				transform.Rotate (Vector3.forward, -rotateZ);
			}
		} else if (!Input.GetButton ("Fire3") && !Input.GetButton ("Jump") && AlignedPosition == false) {

			Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
			transform.position = cursorPosition;
		}
	}


}