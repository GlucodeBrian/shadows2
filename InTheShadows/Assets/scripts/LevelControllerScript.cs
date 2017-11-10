using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControllerScript : MonoBehaviour {

	public static LevelControllerScript instance = null;
	int sceneIndex;
	int levelPassed;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		} else if (instance != null) {
			Destroy (gameObject);
		}

		sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
	}
	
	// Update is called once per frame
	public void youWin () {
		if (sceneIndex == 4) {
			PlayerPrefs.SetInt ("LevelPassed", sceneIndex);
			Invoke ("loadMainMenu", 5f);
		}
		else {
			if (levelPassed < sceneIndex) {
				PlayerPrefs.SetInt ("LevelPassed", sceneIndex);
				//Invoke ("loadNextLevel", 5f);
			}
		}
	}

	public void loadMainMenu() {
		SceneManager.LoadScene ("MainMenu");
	}

	public void loadNextLevel() {
		SceneManager.LoadScene (sceneIndex + 1);
	}
}
