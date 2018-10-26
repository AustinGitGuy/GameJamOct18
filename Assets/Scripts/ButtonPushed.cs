using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPushed : MonoBehaviour {

	public bool isPushed;

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Pot"){
			isPushed = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag == "Pot"){
			isPushed = false;
		}
	}
}
