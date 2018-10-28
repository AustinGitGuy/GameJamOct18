using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

// Script attached to Button in TutorialScene
// Used to section the dialogue portions of the tutorial and tells the next text to appear
public class TutorialButton : MonoBehaviour {

	TutorialManager tutorialManager;

	void Start()
	{
		tutorialManager = GameObject.Find("_TUTORIALMANAGER_").GetComponent<TutorialManager>();
	}

	// Function detects when player moves the skull onto the button to start next part of the tutorial
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Skull"){
			tutorialManager.inDialogue = true;
		}
	}
}