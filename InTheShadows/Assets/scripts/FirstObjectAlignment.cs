using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstObjectAlignment : MonoBehaviour {

	public float precisionRot = 0.0f;
	public float precisionPos = 0.0f;

	public float alignRotX = 0;
	public float alignRotY = 0;
	public float alignRotZ = 0;
	public Vector3 currentRotation;

	public float alignPosX = 0;
	public float alignPosY = 0;
	public float alignPosZ = 0;
	public Vector3 currentPosition;

	public bool AlignedRotation = false;
	public bool AlignedPos = false;
	public bool Aligned = false;

	public GameObject AlignedParticle;

	void Update () {
		CheckAlignment ();
	}

	public void CheckAlignment() {

		Vector3 checkRotation;
		checkRotation.x = alignRotX;
		checkRotation.y = alignRotY;
		checkRotation.z = alignRotZ;

		currentRotation.x = transform.rotation.eulerAngles.x;
		currentRotation.y = transform.rotation.eulerAngles.y;
		currentRotation.z = transform.rotation.eulerAngles.z;

		float bufferX = checkRotation.x - currentRotation.x;
		float bufferY = checkRotation.y - currentRotation.y;
		float bufferZ = checkRotation.z - currentRotation.z;

		if ((bufferX <= precisionRot && bufferX >= -precisionRot) && (bufferY <= precisionRot && bufferY >= -precisionRot) && (bufferZ <= precisionRot && bufferZ >= -precisionRot)) {
			AlignedRotation = true;
			AlignedParticle.SetActive (true);
			AlignedParticle.SetActive (false);
		}

		Vector3 checkPosition;
		checkPosition.x = alignPosX;
		checkPosition.y = alignPosY;
		checkPosition.z = alignPosZ;

		currentPosition = transform.position;

		float posX = checkPosition.x - currentPosition.x;
		float posY = checkPosition.y - currentPosition.y;
		float posZ = checkPosition.z - currentPosition.z;

		Debug.Log ("posx: " + posX);
		Debug.Log ("posy: " + posY);
		Debug.Log ("posz: " + posZ);

		if ((posX <= precisionPos && posX >= -precisionPos) && (posY <= precisionPos && posY >= -precisionPos) && (posZ <= precisionPos && posZ >= -precisionPos)) {
			AlignedPos = true;
			AlignedParticle.SetActive (true);
		}

		if (AlignedPos == true && AlignedRotation == true) {
			Aligned = true;
			AlignedParticle.SetActive (false);
		}
	}
}