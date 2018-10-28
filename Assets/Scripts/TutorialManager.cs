using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script attached to _TUTORIALMANAGER_ in TutorialScene
// Used to control the dialogue and the overall workings of the scene

namespace Managers
{
	public class TutorialManager : MonoBehaviour {

		public GameObject player;
		Rigidbody2D playerRB;

		[Header("Images of the Dialogue")]
		public GameObject NPC;
		public GameObject playerImage;
		public GameObject dialogueBackground;

		[Header("Opening Text")]
		int dialogueState;
		public GameObject text1, text2, text3, text4, text5, text6, text7, text8, text9, text10, text11, text12;

		[Header("Controlling Dialogue")]
		public bool inDialogue;

		[Header("In-Game Objects")]
		public GameObject ring0;
		public GameObject coin0;
		public GameObject lighting;

		void Start()
		{
			player = Managers.PlayerManager.Instance.GetPlayer();
			playerRB = player.GetComponent<Rigidbody2D>();
			playerRB.constraints = RigidbodyConstraints2D.FreezeAll;

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
			text9.SetActive(false);
			text10.SetActive(false);
			text11.SetActive(false);
			text12.SetActive(false);

			ring0.SetActive(false);
			coin0.SetActive(false);
			//lighting.SetActive(false);
		}

		void Update()
		{
			// Checks if the dialogue is reading or if the player is playing the game
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
					text9.SetActive(false);
					text10.SetActive(false);
					text11.SetActive(false);
					text12.SetActive(false);
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
					text6.SetActive(true);
					break;
				case 6:
					text6.SetActive(false);
					inDialogue = false;
					NPC.SetActive(false);
					playerImage.SetActive(false);
					dialogueBackground.SetActive(false);
					playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;
					break;
				case 7:
					playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
					NPC.SetActive(true);
					playerImage.SetActive(true);
					dialogueBackground.SetActive(true);
					text6.SetActive(false);
					text7.SetActive(true);
					ring0.SetActive(true);
					coin0.SetActive(true);
					break;
				case 8:
					text7.SetActive(false);
					text8.SetActive(true);
					break;
				case 9:
					text8.SetActive(false);
					text9.SetActive(true);
					break;
				case 10:
					text9.SetActive(false);
					text10.SetActive(true);
					break;
				case 11:
					text10.SetActive(false);
					text11.SetActive(true);
					break;
				case 12:
					text11.SetActive(false);
					text12.SetActive(true);
					break;
				case 13:
					text12.SetActive(false);
					inDialogue = false;
					NPC.SetActive(false);
					playerImage.SetActive(false);
					dialogueBackground.SetActive(false);
					playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;
					lighting.SetActive(true);
					break;
			}
		}
	}
}