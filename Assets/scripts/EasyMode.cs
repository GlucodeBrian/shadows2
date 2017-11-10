using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMode : MonoBehaviour {

	float rotateSpeed = 180;
	private Vector3 screenPoint;
	public GameObject ObjectAligned;
	public bool Aligned;

	void Start() {
		Aligned = false;
	}

	void OnMouseDrag() {
		Aligned = ObjectAligned.GetComponent<AlignmentCheck>().Aligned;
		if (Input.GetButton ("Fire1") && Aligned == false) {
			float rotateZ = Input.GetAxis ("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
			transform.Rotate (Vector3.forward, rotateZ);
		}
	} 
}