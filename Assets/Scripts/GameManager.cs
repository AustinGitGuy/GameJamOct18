using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class GameManager : Singleton<GameManager> {
    LevelLoader sceneManager;
    private void Awake()
    {
        Debug.Assert(Instance);
    }
    // Use this for initialization
    void Start () {
        sceneManager = gameObject.GetComponent<LevelLoader>();
        Debug.Assert(sceneManager);
	}
	
    

    public LevelLoader getSceneManager()
    {
        return sceneManager; //does this work if it's not a pointer?
    }
}
