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
		public int playerHealth;

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

		[Header("UIText")]
		public Text textRingsCollected;
		public Text textCoinsCollected;

		// Use this for initialization
		void Start () {

			//Initializing time/health varibales
			timer = Managers.TimeManager.Instance.timeLeft;
			playerHealth = Managers.PlayerManager.Instance.health;

			//Initializing the collectibles	
			skullsCollected = Managers.PlayerManager.Instance.totalSkulls;
			ringsCollected = Managers.PlayerManager.Instance.totalRings;
			coinsCollected = Managers.PlayerManager.Instance.totalCollectedCoins;
		}
		
		// Update is called once per frame
		void Update () {
			timer = Managers.TimeManager.Instance.timeLeft;
			skullsCollected = Managers.PlayerManager.Instance.totalSkulls;
			ringsCollected = Managers.PlayerManager.Instance.totalRings;
			coinsCollected = Managers.PlayerManager.Instance.totalCollectedCoins;
			playerHealth = Managers.PlayerManager.Instance.health;
			UpdateCoinUI();
			UpdateRingUI();
			CollectSkulls();
			RemainingHealth();
		}

		//Function changes the health UI in the top right corner. Updates when the player takes damage
		public void RemainingHealth()
		{
			switch(playerHealth)
			{
				case 0:
					health0.sprite = fullHealth;
					health1.sprite = fullHealth;
					health2.sprite = fullHealth;
					health3.sprite = fullHealth;
					health4.sprite = fullHealth;
					break;
				case 1:
					health0.sprite = emptyHealth;
					break;
				case 2:
					health1.sprite = emptyHealth;
					break;
				case 3:
					health2.sprite = emptyHealth;
					break;
				case 4:
					health3.sprite = emptyHealth;
					break;
				case 5:
					health4.sprite = emptyHealth;
					Die();
					break;
			}
		}

		//Function if the player loses all health
		public void Die()
		{
			Debug.Log("UIManager//Die");
			//SceneManager.LoadScene("EndScene");
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
					FinishedCollectingSkulls();
					break;
			}
		}

		//Function if the player collects all skulls
		public void FinishedCollectingSkulls()
		{
			Debug.Log("UIManager//Skulls all collected");
			//Create portal???
		}

		//Function updates the UI text to show how many rings the player has collected/left to use
		public void UpdateRingUI()
		{
			textRingsCollected.text = (ringsCollected.ToString());
		}

		//Function updates the UI text to show how many coins the player has collected
		public void UpdateCoinUI()
		{
			textCoinsCollected.text = (coinsCollected.ToString());
		}
	}
}