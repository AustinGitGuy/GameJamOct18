using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    Rigidbody2D rb;
    float xMove, yMove;
    float moveMod = 5f;
	void Start(){
        rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
        GetInput();
        Move();
	}

    void GetInput(){
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");
    }

    void Move(){
		rb.velocity = new Vector2(xMove * moveMod, yMove * moveMod);
    }
}
