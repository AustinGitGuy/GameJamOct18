using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckButton : MonoBehaviour {

	[SerializeField]
	ButtonPushed button;

	[SerializeField]
	GameObject skull;
	
	void Update(){
		if(skull != null){
			if(button.isPushed){
				skull.gameObject.SetActive(true);
			}
			else {
				skull.gameObject.SetActive(false);
			}
		}
	}
}
