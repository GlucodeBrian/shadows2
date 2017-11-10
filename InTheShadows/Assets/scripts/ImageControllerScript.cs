using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageControllerScript : MonoBehaviour {

	public bool isImg1On;
	public bool isImg2On;
	public bool isImg3On;
	public bool isImg4On;

	public GameObject normalPanel;
	public GameObject imagePanel1;
	public GameObject imagePanel2;
	public GameObject imagePanel3;
	public GameObject imagePanel4;

	void Start () {

		isImg1On = false;
		isImg2On = false;
		isImg3On = false;
		isImg4On = false;
	}

	void Update () {
		isImg1On = normalPanel.GetComponent<MainMenuConroller> ().isImg1On;
		isImg2On = normalPanel.GetComponent<MainMenuConroller> ().isImg2On;
		isImg3On = normalPanel.GetComponent<MainMenuConroller> ().isImg3On;
		isImg4On = normalPanel.GetComponent<MainMenuConroller> ().isImg4On;

		if (isImg1On == true) {
			this.imagePanel1.SetActive (true);
		}
		if (isImg2On == true) {
			this.imagePanel2.SetActive (true);
		}
		if (isImg3On == true) {
			this.imagePanel3.SetActive (true);
		}
		if (isImg4On == true) {
			this.imagePanel4.SetActive (true);
		}
		if (isImg1On == false) {
			this.imagePanel1.SetActive (false);
		}
		if (isImg2On == false) {
			this.imagePanel2.SetActive (false);
		}
		if (isImg3On == false) {
			this.imagePanel3.SetActive (false);
		}
		if (isImg4On == false) {
			this.imagePanel4.SetActive (false);
		}
	}
}
