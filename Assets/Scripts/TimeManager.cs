using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Timer for how long the player has left.
namespace Managers {
public class TimeManager : Singleton<TimeManager> {
		public float timeLeft;
		public float totalTime;
		void Start(){
			timeLeft = totalTime;
		}

		void Update(){
			timeLeft -= Time.deltaTime;
			if(timeLeft < 0){
				Managers.PlayerManager.Instance.HealthMod(-1);
				Managers.GameManager.Instance.getSceneManager().ReloadLevel();
			}
		}
	}
}
