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
		startPos = line.GetPosition(0);
		endPos = line.GetPosition(1);
		endPos = new Vector2(endPos.x + .2f, endPos.y);
		distance = Vector2.Distance(startPos, endPos);
		RaycastHit2D hit = Physics2D.Raycast(startPos, endPos - startPos, distance);
		if(hit && hit.transform.tag == "Player"){
			if(!Managers.PlayerManager.Instance.isDissolving){
				StartCoroutine(Managers.PlayerManager.Instance.DissolvePlayer());
			}
		}
	}
}
