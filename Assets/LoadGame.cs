using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

	void Start(){
		
	}
	
	public void LoadStart(){
		SceneManager.LoadScene("Game");
	}
}
