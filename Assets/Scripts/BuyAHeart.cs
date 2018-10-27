using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyAHeart : MonoBehaviour {

	GameObject player;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
	}
	
	void Update(){
		if(Vector2.Distance(player.transform.position, this.transform.position) <= 2){
			if(Input.GetKeyDown(KeyCode.E) && Managers.PlayerManager.Instance.totalCollectedCoins >= 5 && Managers.PlayerManager.Instance.health > 0){
				Managers.PlayerManager.Instance.HealthMod(-1);
				Destroy(this.gameObject);
			}
		}
	}
}
