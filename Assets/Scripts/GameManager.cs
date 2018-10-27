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
        Tilemap groundTileMap;
        private void Awake()
        {
            Debug.Assert(Instance);
        }
        // Use this for initialization
        void Start()
        {
            sceneManager = gameObject.GetComponent<LevelLoader>();
            Debug.Assert(sceneManager);
            groundTileMap = GameObject.Find("Background").GetComponent<Tilemap>();
            Debug.Assert(groundTileMap);
        }


        public Tilemap getGroundTileMap()
        {
            return groundTileMap;
        }
        public LevelLoader getSceneManager()
        {
            return sceneManager;
        }
    }
}
