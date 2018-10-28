﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If player is close enough and has enough rings, open the door.
public class CheckRings : MonoBehaviour {

	bool doorOpen;
	GameObject player;

	[SerializeField]
	int requiredRingNum = 1;

	[SerializeField]
	bool vertical;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
	}
	
	void Update(){
		if(Vector2.Distance(player.transform.position, this.transform.position) <= 5 && !doorOpen){
			if(Input.GetKeyDown(KeyCode.E)){
				if(Managers.PlayerManager.Instance.totalRings >= requiredRingNum){
					doorOpen = true;
					Managers.PlayerManager.Instance.totalRings -= requiredRingNum;
					//Temporary door just moves to the side
					if(!vertical){
						transform.position = new Vector2(transform.position.x - 2.5f, transform.position.y);
					}
					else {
						transform.position = new Vector2(transform.position.x, transform.position.y - 2.5f);
					}
				}
			}
		}
	}

	public bool GetDoorOpen(){
		return doorOpen;
	}
}
