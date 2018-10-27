using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDoor : MonoBehaviour {

	bool doorOpen;
	GameObject player;
	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
	}
	
	void Update(){
		if(Vector2.Distance(player.transform.position, this.transform.position) <= 5 && !doorOpen){
			if(Input.GetKeyDown(KeyCode.E)){
				if(Managers.PlayerManager.Instance.totalSkulls >= 5){
					doorOpen = true;
					Managers.PlayerManager.Instance.totalSkulls -= 5;
					//Temporary door just moves to the side
					transform.position = new Vector2(transform.position.x - 2, transform.position.y);
				}
			}
		}
	}

	public bool GetDoorOpen(){
		return doorOpen;
	}
}
