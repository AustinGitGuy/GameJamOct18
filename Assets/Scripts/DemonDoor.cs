using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if player is close enough and has enough skulls, open the door.
public class DemonDoor : MonoBehaviour {

	bool doorOpen;
    bool sound;
	GameObject player;
	[SerializeField]
	int skullNum;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
	}
	
	void Update(){
		if(Vector2.Distance(player.transform.position, this.transform.position) <= 5 && !doorOpen){
			if(Input.GetKeyDown(KeyCode.E)){
				if(Managers.PlayerManager.Instance.totalSkulls >= skullNum){
					doorOpen = true;
					Managers.PlayerManager.Instance.totalSkulls -= skullNum;
					Managers.GameManager.Instance.getSceneManager().goShopping();
					transform.position = new Vector2(transform.position.x - 2, transform.position.y);
				}
			}
		}
        if ((sound == false) && (doorOpen == true))
        {
            Managers.SoundManagerScript.Instance.playPortalSound();
            sound = true;
        }
	}

	public bool GetDoorOpen(){
		return doorOpen;
	}
}
