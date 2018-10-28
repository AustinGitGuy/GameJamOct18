using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script attached to _STOREMANAGER_ in MerchantScene
//Used to control all store transactions
namespace Managers
{
	public class StoreManager : MonoBehaviour {

		LevelLoader sceneManager;

		public int coins;
		public Text coinsText;

		// Bools to see what the player is viewing or trying to buy
		bool lookingAtJingleBell;
		bool lookingAtWaterVase;
		bool buyJingleBell;
		bool buyWaterVase;

		// GameObjects that hold all of the information for the item
		public GameObject jingleBellPanel;
		public GameObject waterVasePanel;
		
		public Text jingleBellPriceText;
		public Text waterVasePriceText;

		int jingleBellPrice = 3;
		int waterVasePrice = 1;

		// Use this for initialization
		void Start () {
			
			sceneManager = GameManager.Instance.getSceneManager();	

			coins = Managers.PlayerManager.Instance.totalCollectedCoins;
			coinsText.text = (coins.ToString());

			jingleBellPanel.SetActive(false);
			waterVasePanel.SetActive(false);
			jingleBellPriceText.text = (jingleBellPrice.ToString() + " coins");
			waterVasePriceText.text = (waterVasePrice.ToString() + " coins");
			lookingAtJingleBell = false;
			lookingAtWaterVase = false;
			buyJingleBell = false;
			buyWaterVase = false;
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		// When the jingle bell putton is clicked, the information panel appears and allows the player to purchase jinglebells
		public void ViewJingleBell()
		{
			jingleBellPanel.SetActive(true);
			lookingAtJingleBell = true;
		}

		// When the water vase putton is clicked, the information panel appears and allows the player to purchase water vases
		public void ViewWaterVase()
		{
			waterVasePanel.SetActive(true);
			lookingAtWaterVase = true;
		}

		// If the player chooses not to buy an item they are viewing, the window is hidden and they can look at the other items
		public void CloseItemWindow()
		{
			if (lookingAtJingleBell)
			{
				jingleBellPanel.SetActive(false);
				lookingAtJingleBell = false;
			}

			if (lookingAtWaterVase)
			{
				waterVasePanel.SetActive(false);
				lookingAtWaterVase = false;
			}
		}

		public void PurchaseItem()
		{
			// Increases player's lives by one
			if(lookingAtJingleBell)
			{
				if(!buyJingleBell)
				{
					buyJingleBell = true;
					Managers.PlayerManager.Instance.health++;
					Managers.PlayerManager.Instance.totalCollectedCoins = Managers.PlayerManager.Instance.totalCollectedCoins - jingleBellPrice;
				}
			}

			if(lookingAtWaterVase)
			{
				if(!buyWaterVase)
				{
					buyWaterVase = true;
					//INCREASE PLAYER SPEED
					Managers.PlayerManager.Instance.totalCollectedCoins = Managers.PlayerManager.Instance.totalCollectedCoins - waterVasePrice;
				}
			}
		}

		public void CheckPrice()
		{
			if(lookingAtJingleBell)
			{
				if (coins >= jingleBellPrice)
				{
					PurchaseItem();
				}
			}

			if(lookingAtWaterVase)
			{
				if (coins >= waterVasePrice)
				{
					PurchaseItem();
				}
			}

		}

		// Once the player is finished purchasing items at the store, they can chose to leave and go to the next level
		public void LeaveStore()
		{
			Debug.Log("StoreManager/LeaveStore");
            sceneManager.stopShopping();
		}
	}
}