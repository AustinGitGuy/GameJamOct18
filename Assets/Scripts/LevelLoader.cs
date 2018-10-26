using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum Scenes
{
    GAME = 0,
    START = 1,
    MENU = 2,
    LEVEL_ONE = 3,
}
public class LevelLoader : MonoBehaviour {
    int currentLevel; //currently loaded level.
    int nextLevel; //next level to load.
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadNextLevel()
    {

    }


}
