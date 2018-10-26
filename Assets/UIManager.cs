using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script attached to _UIMANAGER_ in GameUIScene
//Used to keep track of the UI elements and control the UI elements
namespace Managers
{
	public class UIManager : Singleton <UIManager>
	{
		[Header("Time/Health")]
		public float timer;
		public float playerHealth;

		[Header("Collectibles")]
		public int skullsCollected;
		public int ringsCollected;
		public int coinsCollected;

		[Header("UIImages")]
		//health UI Images
		public Image health0;
		public Image health1;
		public Image health2;
		public Image health3;
		public Image health4;
		//health sprites set in inspector
		public Sprite emptyHealth;
		public Sprite fullHealth;
		//skull UI Images
		public Image skull0;
		public Image skull1;
		public Image skull2;
		public Image skull3;
		public Image skull4;
		//skull sprites set in inspector
		public Sprite emptySkull;
		public Sprite collectedSkull;

		// Use this for initialization
		void Start () {



			//Initializing the collectibles
			skullsCollected = 0;
			ringsCollected = 0;
			coinsCollected = 0;

			//Fetch the Images from the GameObject
			health0 = GetComponent<Image>();
			health1 = GetComponent<Image>();
			health2 = GetComponent<Image>();
			health3 = GetComponent<Image>();
			health4 = GetComponent<Image>();
			skull0 = GetComponent<Image>();
			skull1 = GetComponent<Image>();
			skull2 = GetComponent<Image>();
			skull3 = GetComponent<Image>();
			skull4 = GetComponent<Image>();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		//Function changes the skull UI in the top right corner. Updates when the player collects a skull
		public void CollectSkulls()
		{
			switch(skullsCollected)
			{
				case 0:
					skull0.sprite = emptySkull;
					skull1.sprite = emptySkull;
					skull2.sprite = emptySkull;
					skull3.sprite = emptySkull;
					skull4.sprite = emptySkull;
					break;
				case 1:
					skull0.sprite = collectedSkull;
					break;
				case 2:
					skull1.sprite = collectedSkull;
					break;
				case 3:
					skull2.sprite = collectedSkull;
					break;
				case 4:
					skull3.sprite = collectedSkull;
					break;
				case 5:
					skull4.sprite = collectedSkull;
					break;
			}
		}

		
	}
}