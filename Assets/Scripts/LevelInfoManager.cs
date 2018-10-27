using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Managers
{
    public class LevelInfoManager : Singleton<LevelInfoManager>
    {
        [SerializeField]
        Tilemap groundTileMap;
        [SerializeField]
        Tilemap colliderTileMap;


        public Tilemap getGroundTileMap()
        {
            return groundTileMap;
        }
        public Tilemap getColliderTileMap()
        {
            return colliderTileMap;
        }
    }
}
