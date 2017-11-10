using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuConroller : MonoBehaviour {

    public Button level02Button, level03Button, level04Button;
	public bool isImg1On, isImg2On, isImg3On, isImg4On;

    int levelPassed;

	void Start () {
		
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        level02Button.interactable = false;
        level03Button.interactable = false;
        level04Button.interactable = false;

		isImg1On = false;
		isImg2On = false;
		isImg3On = false;
		isImg4On = false;
//	}
//	void Update()
//	{
		switch (levelPassed)
		{
		case 1:
			level02Button.interactable = true;

			isImg1On = true;
			break;
		case 2:
			level02Button.interactable = true;
			level03Button.interactable = true;

			isImg1On = true;
			isImg2On = true;
			break;
		case 3:
			level02Button.interactable = true;
			level03Button.interactable = true;
			level04Button.interactable = true;

			isImg1On = true;
			isImg2On = true;
			isImg3On = true;
			break;
		case 4:
			level02Button.interactable = true;
			level03Button.interactable = true;
			level04Button.interactable = true;

			isImg1On = true;
			isImg2On = true;
			isImg3On = true;
			isImg4On = true;
			break;
		}
	}
		
	public void levelToLoad (int level) {
        SceneManager.LoadScene(level);
	}

    public void resetPlayerPrefs()
    {
        level02Button.interactable = false;
        level03Button.interactable = false;
        level04Button.interactable = false;

		isImg1On = false;
		isImg2On = false;
		isImg3On = false;
		isImg4On = false;

        PlayerPrefs.DeleteAll();
    }
}