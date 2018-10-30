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
        cameraPointsScript cameraScript;
        [SerializeField]
        GameObject cameraObject1, cameraObject2; //Objects for camera tracking.
        private void Awake()
        {
            Debug.Assert(Instance);
            sceneManager = gameObject.GetComponent<LevelLoader>();
            Debug.Assert(sceneManager);
            cameraScript = null;
        }
        // Use this for initialization
        void Start()
        {
            
        }

        //Called from cameraPointsScript and LevelLoader to clear
        public void LoadedNewCameraLevel(cameraPointsScript cps)
        {
            cameraScript = cps;
            if (!cameraScript)
            {
                cameraObject1.transform.position = Vector3.zero;
                cameraObject2.transform.position = Vector3.zero;
            }
            else {
                Managers.TimeManager.Instance.totalTime = cameraScript.totalTime;
                Managers.TimeManager.Instance.timeLeft = cameraScript.totalTime;
            }
        }

        public Tilemap getGroundTileMap()
        {
            return LevelInfoManager.Instance.getGroundTileMap();
        }
        public LevelLoader getSceneManager()
        {
            return sceneManager;
        }

        public void updateCamera(Vector2 playerPosit)
        {
            if (cameraScript)
            {
                cameraScript.setRoomPosition(playerPosit);
                cameraObject1.transform.position = cameraScript.getBotRight();
                cameraObject2.transform.position = cameraScript.getTopLeft();
            }
        }
    }
}
