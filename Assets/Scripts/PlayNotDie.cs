using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNotDie : MonoBehaviour {
	bool play;

	public void Play(){
		if(!play){
			play = true;	
			transform.Find("Particle").GetComponent<ParticleSystem>().Play();
		}
	}
}
