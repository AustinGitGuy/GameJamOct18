using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Matches scenes in build menu
enum Scenes
{
    GAME = 0,
    START,
    SOUND,
    UI,
    LEVEL_ONE = 4,
}

//Encapsulation of SceneManagement
public class LevelLoader : MonoBehaviour {
    int currentScene = -1; //currently loaded level.
    int nextScene; //next level to load.
    int prevScene = -1;

    private void Start()
    {
        setupGame();
    }

    //Load the composite scenes and the main menu
    private void setupGame()
    {
        SceneManager.LoadScene((int)Scenes.START, LoadSceneMode.Additive);
        SceneManager.LoadScene((int)Scenes.SOUND, LoadSceneMode.Additive);
        SceneManager.LoadScene((int)Scenes.UI, LoadSceneMode.Additive);
        currentScene = (int)Scenes.START;
        nextScene = (int)Scenes.LEVEL_ONE;
    }

    public void quit()
    {
        Application.Quit();
    }
    //Load the next level and incremement the next level to load
    public void loadNextLevel()
    {
        //if scene not already loaded.
        if (currentScene != nextScene && prevScene < 0)
        {
            SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
            prevScene = currentScene;
            currentScene = nextScene;
            nextScene++;
        }
        else
        {
            Debug.LogError("Did you unload the previous scene?");
        }
    }

    //Unload the previous level.
    public void unloadLastLevel()
    {
        if(prevScene > 0)
        {
            SceneManager.UnloadSceneAsync(prevScene);
            prevScene = -1;
        }
        else
        {
            Debug.LogError("Previous Scene Already unloaded");
        }
    }


}
