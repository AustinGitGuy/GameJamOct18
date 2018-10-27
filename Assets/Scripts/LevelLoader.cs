using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum Scenes
{
    GAME = 0,
    START = 1,
    MENU = 2,
    SOUND = 3,
    LEVEL_ONE = 4,
}
public class LevelLoader : MonoBehaviour {
    int currentScene = -1; //currently loaded level.
    int nextScene; //next level to load.
    int prevScene = -1;

    private void Start()
    {
        setupGame();
    }

    private void setupGame()
    {
        SceneManager.LoadScene((int)Scenes.GAME);
        SceneManager.LoadScene((int)Scenes.START);
        SceneManager.LoadScene((int)Scenes.SOUND);
        currentScene = (int)Scenes.START;
        nextScene = (int)Scenes.LEVEL_ONE;
    }
    public void loadMainMenu()
    {
        SceneManager.UnloadSceneAsync((int)Scenes.START);
        SceneManager.LoadScene((int)Scenes.MENU);
    }
    public void unloadMainMenu()
    {
        SceneManager.UnloadSceneAsync((int)Scenes.MENU);
        SceneManager.LoadScene((int)Scenes.START);
    }
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
