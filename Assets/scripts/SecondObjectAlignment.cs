using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondObjectAlignment : MonoBehaviour {

	public int sceneIndex;

	public float alignX = 0;
	public float alignY = 0;
	public float alignZ = 0;
	public float precision = 2.0f;

	public Vector3 currentRotation;

	public bool Aligned1;
	public bool Aligned2;

	public GameObject FireworksParticle;
	public GameObject AlignedParticle;
	public GameObject firstObject;
	public GameObject levelCompletePanel;

	public AudioClip applause;
	public AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		levelCompletePanel.gameObject.SetActive (false);
		sceneIndex = SceneManager.GetActiveScene().buildIndex;
		StartCoroutine(applauseClip());
		Aligned1 = false;
	}

	IEnumerator applauseClip()
	{
		yield return new WaitUntil(() => Aligned1 == true && Aligned2 == true);
		audioSource.PlayOneShot(applause, 0.7F);
	}

	void Update () {
			CheckAlignment ();
	}

	public void CheckAlignment() {

		Aligned2 = firstObject.GetComponent<FirstObjectAlignment> ().Aligned;

		Vector3 check;

		check.x = alignX;
		check.y = alignY;
		check.z = alignZ;

		currentRotation.x = transform.rotation.eulerAngles.x;
		currentRotation.y = transform.rotation.eulerAngles.y;
		currentRotation.z = transform.rotation.eulerAngles.z;

		float bufferX = check.x - currentRotation.x;
		float bufferY = check.y - currentRotation.y;
		float bufferZ = check.z - currentRotation.z;

		if ((bufferX <= precision && bufferX >= -precision) && (bufferY <= precision && bufferY >= -precision) && (bufferZ <= precision && bufferZ >= -precision)) {
			Aligned1 = true;
			AlignedParticle.SetActive (true);
			if (Aligned1 == true && Aligned2 == true) {
				FireworksParticle.SetActive (true);
				levelCompletePanel.gameObject.SetActive (true);
				LevelControllerScript.instance.youWin ();
			}
		}
	}
}
