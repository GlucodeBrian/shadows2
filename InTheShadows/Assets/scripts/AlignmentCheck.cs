using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AlignmentCheck : MonoBehaviour {


	public int sceneIndex;

	public float alignX = 0;
	public float alignY = 0;
	public float alignZ = 0;
	public float precision = 3.0f;
	public Vector3 currentRotation;

	public bool Aligned;

	public GameObject FireworksParticle;
	public GameObject AlignedParticle;
	public GameObject levelCompletePanel;

	public AudioClip applause;
	public AudioSource audioSource;


	void Start () {
		audioSource = GetComponent<AudioSource>();
		sceneIndex = SceneManager.GetActiveScene().buildIndex;
		levelCompletePanel.gameObject.SetActive (false);
		StartCoroutine(applauseClip());
		Aligned = false;
	}

	IEnumerator applauseClip()
	{
		yield return new WaitUntil(() => Aligned == true);
		audioSource.PlayOneShot(applause, 0.7F);
	}

	void Update () {
		CheckAlignment ();
	}

	public void CheckAlignment() {

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
			Aligned = true;
			FireworksParticle.SetActive (true);
			LevelControllerScript.instance.youWin ();
			levelCompletePanel.gameObject.SetActive (true);
			AlignedParticle.SetActive (true);
//			StartCoroutine (WaitForIt (5.0F));
		}
	}

//	IEnumerator WaitForIt(float waitTime)
//	{
//		yield return new WaitForSeconds(waitTime);
//		LevelControllerScript.instance.youWin ();
//	}
}
