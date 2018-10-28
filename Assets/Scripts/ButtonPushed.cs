using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPushed : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Skull"){
            Managers.SoundManagerScript.Instance.playSkullOnBloodSound();
			Managers.PlayerManager.Instance.SkullCollected(1);
			Destroy(col.gameObject);
		}
	}
}
