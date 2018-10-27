using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If button is pushed, enable a skull, if not disable it.
public class CheckButton : MonoBehaviour {

	[SerializeField]
	ButtonPushed button;

	[SerializeField]
	GameObject skull;
	
	void Update(){
		if(skull != null){
			if(button.isPushed){
				skull.gameObject.SetActive(true);
				skull.GetComponent<PlayNotDie>().Play();
			}
			else {
				skull.gameObject.SetActive(false);
			}
		}
	}
}
