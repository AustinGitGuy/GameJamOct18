using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Managers
{
    //Handles level loading and game information
    public class GameManager : Singleton<GameManager>
    {
        LevelLoader sceneManager;
        private void Awake()
        {
            Debug.Assert(Instance);
            sceneManager = gameObject.GetComponent<LevelLoader>();
            Debug.Assert(sceneManager);
        }
        // Use this for initialization
        void Start()
        {
            
        }


        public Tilemap getGroundTileMap()
        {
            return LevelInfoManager.Instance.getGroundTileMap();
        }
        public LevelLoader getSceneManager()
        {
            return sceneManager;
        }
    }
}
