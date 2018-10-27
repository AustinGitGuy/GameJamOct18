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
        sceneManager = Managers.GameManager.Instance.getSceneManager();
        Debug.Assert(sceneManager);
    }
}