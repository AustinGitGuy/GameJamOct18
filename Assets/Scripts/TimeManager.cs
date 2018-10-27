using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers {
public class TimeManager : Singleton<TimeManager> {
		public float timeLeft;
		public float totalTime;
		void Start(){
			timeLeft = totalTime;
		}

		void Update(){
			timeLeft -= Time.deltaTime;
		}
	}
}
