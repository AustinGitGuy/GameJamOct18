using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotStop : MonoBehaviour {

	[SerializeField]
	bool isTouching;
	Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
		if(!isTouching){
			rb.velocity = Vector3.zero;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		isTouching = true;
	}
	
	void OnCollisionExit2D(Collision2D col){
		isTouching = false;
	}
}
