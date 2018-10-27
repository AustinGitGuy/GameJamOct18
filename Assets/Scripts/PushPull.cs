﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=Qz2qMxmtxpQ

public class PushPull : MonoBehaviour {

	public float distance = 1f;
	public LayerMask boxMask;
	GameObject box;

	void Update(){
		Physics2D.queriesStartInColliders = false;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
			if(hit.collider != null && hit.collider.gameObject.tag == "Barrel" && Input.GetKeyDown(KeyCode.E)){
				box = hit.collider.gameObject;
				box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
				box.GetComponent<FixedJoint2D>().enabled = true;
				box.GetComponent<BoxPull>().beingPushed = true;
			} 
			else if(Input.GetKeyUp(KeyCode.E) && box != null){
				box.GetComponent<FixedJoint2D>().enabled = false;
				box.GetComponent<BoxPull>().beingPushed = false;
			}	
	}
}