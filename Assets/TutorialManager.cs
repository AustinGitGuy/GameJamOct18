using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

	public GameObject NPC;
	public GameObject playerImage;
	public GameObject dialogueBackground;

	[Header("Opening Text")]
	int dialogueState;
	public GameObject text1, text2, text3, text4, text5, text6, text7, text8;

	[Header("Controlling Dialogue")]
	public bool inDialogue;

	void Start()
	{
		dialogueState = 0;
		inDialogue = true;

		NPC.SetActive(true);
		playerImage.SetActive(true);
		dialogueBackground.SetActive(true);

		text1.SetActive(true);
		text2.SetActive(false);
		text3.SetActive(false);
		text4.SetActive(false);
		text5.SetActive(false);
		text6.SetActive(false);
		text7.SetActive(false);
		text8.SetActive(false);
	}

	void Update()
	{
		if (inDialogue)
		{
			if (Input.anyKeyDown)
			{
				//Debug.Log("A key or mouse click has been detected");
				dialogueState++;
				DialogueState();
			}
		}
	}

	// Function controls when the dialogue is visible and when the player can move around
	void DialogueState()
	{
		switch(dialogueState)
		{
			case 0:
				text1.SetActive(true);
				text2.SetActive(false);
				text3.SetActive(false);
				text4.SetActive(false);
				text5.SetActive(false);
				text6.SetActive(false);
				text7.SetActive(false);
				text8.SetActive(false);
				break;
			case 1:
				text1.SetActive(false);
				text2.SetActive(true);
				break;
			case 2:
				text2.SetActive(false);
				text3.SetActive(true);
				break;
			case 3:
				text3.SetActive(false);
				text4.SetActive(true);
				break;
			case 4:
				text4.SetActive(false);
				text5.SetActive(true);
				break;
			case 5:
				text5.SetActive(false);
				inDialogue = false;
				NPC.SetActive(false);
				playerImage.SetActive(false);
				dialogueBackground.SetActive(false);
				break;
			case 6:
				NPC.SetActive(true);
				playerImage.SetActive(true);
				dialogueBackground.SetActive(true);
				text5.SetActive(false);
				text6.SetActive(true);
				break;
			case 7:
				text6.SetActive(false);
				text7.SetActive(true);
				break;
			case 8:
				text7.SetActive(false);
				text8.SetActive(true);
				break;
			case 9:
				text8.SetActive(false);
				inDialogue = false;
				NPC.SetActive(false);
				playerImage.SetActive(false);
				dialogueBackground.SetActive(false);
				break;
		}
	}
}
