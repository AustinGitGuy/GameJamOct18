using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If player is close enough and has enough rings, open the door.
public class CheckRings : MonoBehaviour {
	bool doorOpen;
	GameObject player;
	[SerializeField]
	GameObject otherDoor;
	[SerializeField]
	int requiredRingNum = 1;
	GameObject teleport;
	CheckRings otherRings;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
		teleport = otherDoor.transform.Find("Teleport").gameObject;
		otherRings = otherDoor.GetComponent<CheckRings>();
	}
	
	void Update(){
		if(otherRings.GetDoorOpen()){
			doorOpen = true;
		}
		if(Vector2.Distance(player.transform.position, this.transform.position) <= 3){
			if(Input.GetKeyDown(KeyCode.E)){
				if(Managers.PlayerManager.Instance.totalRings >= requiredRingNum && !doorOpen){
                    Managers.SoundManagerScript.Instance.playDoorSound();
					doorOpen = true;
					Managers.PlayerManager.Instance.totalRings -= requiredRingNum;
					player.transform.position = new Vector2(teleport.transform.position.x, teleport.transform.position.y);

				}
				else if(doorOpen){
					player.transform.position = new Vector2(teleport.transform.position.x, teleport.transform.position.y);
				}
			}
		}
		
	}

	public bool GetDoorOpen(){
		return doorOpen;
	}
}
