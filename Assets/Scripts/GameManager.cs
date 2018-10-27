using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    //Handles level loading and game information
    public class GameManager : Singleton<GameManager>
    {
        LevelLoader sceneManager;
        private void Awake()
        {
            Debug.Assert(Instance);
        }
        // Use this for initialization
        void Start()
        {
            sceneManager = gameObject.GetComponent<LevelLoader>();
            Debug.Assert(sceneManager);
        }



        public LevelLoader getSceneManager()
        {
            return sceneManager;
        }
    }
}
