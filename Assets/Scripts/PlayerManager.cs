using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers{
	public class PlayerManager : Singleton<PlayerManager> {

		public int totalCollectedCoins = 0;
		GameObject playerObject;

		void Start(){
			GetPlayer();
		}

		public void CoinCollected(int coinValue){
			totalCollectedCoins += coinValue;
		}

		public GameObject GetPlayer(){
			if(playerObject == null){
				playerObject = GameObject.Find("Player");
			}
			return playerObject;
		}
	}
}
