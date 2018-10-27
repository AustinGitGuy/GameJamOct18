﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//stores and manages player info
namespace Managers{
	public class PlayerManager : Singleton<PlayerManager> {

		public int totalCollectedCoins = 0;
		public int totalRings = 0;
		public int totalSkulls = 0;
		public int health;
		GameObject playerObject;

		void Start(){
			GetPlayer();
            Debug.Assert(Managers.GameManager.Instance);

        }

        void Update(){
			float frac = Managers.TimeManager.Instance.totalTime / Managers.TimeManager.Instance.timeLeft;
			health = Mathf.Abs(5 - Mathf.FloorToInt(5 * frac));
		}

		public void CoinCollected(int coinValue){
			totalCollectedCoins += coinValue;
		}

		public void RingCollected(int rings){
			totalRings += rings;
		}

		public void SkullCollected(int skulls){
			totalSkulls += skulls;
		}

		public void HealthMod(int mod){
			health += mod;
		}

		public GameObject GetPlayer(){
			if(playerObject == null){
				playerObject = GameObject.Find("Player");
			}
			return playerObject;
		}

        public string getTileName()
        {
            Vector3Int tilePosit = new Vector3Int((int)transform.position.x , (int)transform.position.y, (int)transform.position.z);
            Tile tile = (Tile)Managers.GameManager.Instance.getGroundTileMap().GetTile(tilePosit);
            if (tile)
            {
                return tile.name;
            }
            return "none";
        }
	}
}
