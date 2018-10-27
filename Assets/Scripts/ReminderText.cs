using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReminderText : MonoBehaviour {

	GameObject player;
	FadingText text;

	[SerializeField]
	bool doorReminder;
	[SerializeField]
	float range;

	void Start(){
		text = transform.Find("ReminderText").GetComponent<FadingText>();
		player = Managers.PlayerManager.Instance.GetPlayer();
	}
	
	void Update(){
		if(Vector2.Distance(player.transform.position, this.transform.position) <= range){
			if(doorReminder && !GetComponent<CheckRings>().GetDoorOpen()){
				text.FadeIn();
			}
			else if(!doorReminder){
				text.FadeIn();
			}
			else {
				text.FadeOut();
			}
		}
		else {
			text.FadeOut();
		}
	}
}
