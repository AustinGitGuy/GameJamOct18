using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPot : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			Vector2 dir = gameObject.transform.position - col.transform.position;
			dir = new Vector2(Mathf.Round(dir.x), Mathf.Round(dir.y));
			transform.position = new Vector3(transform.position.x + dir.x, transform.position.y + dir.y, transform.position.z);
		}
	}
}
