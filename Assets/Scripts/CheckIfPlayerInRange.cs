using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfPlayerInRange : MonoBehaviour {

	LineRenderer line;
	public Vector2 startPos;
	public Vector2 endPos;
	float distance;

	void Start(){
		line = GetComponent<LineRenderer>();
	}
	
	void Update(){
		CheckHit();
	}

	void CheckHit(){

	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			if(!Managers.PlayerManager.Instance.isDissolving){
				StartCoroutine(Managers.PlayerManager.Instance.DissolvePlayer());
			}
		}
	}
}
