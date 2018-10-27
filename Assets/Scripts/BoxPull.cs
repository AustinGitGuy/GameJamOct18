﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=Qz2qMxmtxpQ

public class BoxPull : MonoBehaviour {
	public float defaultMass;
	public float imovableMass;
	public bool beingPushed;
	float xPos;

	public Vector3 lastPos;

	public int mode;
	public int colliding;

	Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		xPos = transform.position.x;
		lastPos = transform.position;
	}
	
	void FixedUpdate(){
		if(!beingPushed){
			rb.velocity = Vector3.zero;
		}
		if(mode == 0){
			if(beingPushed == false){
				transform.position = new Vector3(xPos, transform.position.y);
			} 
			else {
				xPos = transform.position.x;
			}
		}
		else if(mode == 1){
			if(!beingPushed){
				rb.mass = imovableMass;
			} 
			else {
				rb.mass = defaultMass;
			}
		}
	}
}