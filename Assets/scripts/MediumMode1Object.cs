using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumMode1Object : MonoBehaviour {

	float rotateSpeed = 180;
	private Vector3 screenPoint;

	public bool Aligned = false;
	public GameObject SecondObjectAligned;
	void OnMouseDrag() {

		Aligned = SecondObjectAligned.GetComponent<AlignmentCheck> ().Aligned;

		if (Input.GetButton ("Fire3") && Aligned == false) {
			if (Input.GetButton ("Fire1")) {
				float rotateY = Input.GetAxis ("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;;
				transform.Rotate (Vector3.right, rotateY);
			}
		}
		if (Input.GetButton ("Jump") && Aligned == false) {

			if (Input.GetButton ("Fire1")) {
				float rotateZ = Input.GetAxis ("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
				transform.Rotate (Vector3.forward, -rotateZ);
			}
		} 
	}
}