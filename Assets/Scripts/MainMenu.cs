using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script attached to _MENUMANAGER_ in MainMenuScene
//Used to control the button functions
public class MainMenu : MonoBehaviour {
    LevelLoader sceneManager; 
    //Use LevelLoader for all scene loading / unloading needs
    private void Start()
    {
        sceneManager = GameManager.Instance.getSceneManager();
        Debug.Assert(sceneManager);
    }
    //Function is attached to the Play button and is used to advance the game to the next scene
    public void PlayGame()
	{
		Debug.Log("Play Game");
		sceneManager.loadNextLevel();
        sceneManager.unloadLastLevel();
	}

	//Function is attached to the Quit button and is used to leave the application
	public void QuitGame()
	{
		Debug.Log("Quit Game");
        sceneManager.quit();
	}
}
