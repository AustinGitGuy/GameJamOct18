using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReminderText : MonoBehaviour {

	GameObject player;
	FadingText text;

	void Start(){
		text = transform.Find("ReminderText").GetComponent<FadingText>();
		text.TurnOff();
		player = Managers.PlayerManager.Instance.GetPlayer();
	}
	
	void Update(){
		if(Vector2.Distance(player.transform.position, this.transform.position) <= 3){
            text.FadeIn();
		}
		else {
			text.FadeOut();
		}
	}
}
