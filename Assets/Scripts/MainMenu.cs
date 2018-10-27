using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script attached to _MENUMANAGER_ in MainMenuScene
//Used to control the button functions
public class MainMenu : MonoBehaviour {

	//Function is attached to the Play button and is used to advance the game to the next scene
	public void PlayGame()
	{
		Debug.Log("Play Game");
		//SceneManager.LoadScene("");
	}

	//Function is attached to the Quit button and is used to leave the application
	public void QuitGame()
	{
		Debug.Log("Quit Game");
		Application.Quit();
	}
}
