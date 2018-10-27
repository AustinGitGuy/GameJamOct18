using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotStop : MonoBehaviour {
	Rigidbody2D rb;
	Rigidbody2D playerRb;
	GameObject player;
	[SerializeField]
	bool isMoving;
	[SerializeField]
	float speedMove;
	Vector2 dir;
	Vector3 pos;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
		playerRb = player.GetComponent<Rigidbody2D>();
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
		MovePosition();
	}

	void MovePosition(){
		if(isMoving){
			if(Vector2.Distance(pos, transform.position) > .05f){
				Vector3 direction = (pos - transform.position).normalized;
				Vector3 playerDirection = (pos - player.transform.position).normalized;
				rb.MovePosition(transform.position + direction * Time.deltaTime * speedMove);
				playerRb.MovePosition(player.transform.position + playerDirection * Time.deltaTime * speedMove);
			}
			else {
				isMoving = false;
				Managers.PlayerManager.Instance.isAnim = false;
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			Managers.PlayerManager.Instance.isAnim = true;
			isMoving = true;
			dir = gameObject.transform.position - col.transform.position;
			if(Mathf.Abs(dir.x) > Mathf.Abs(dir.y)){
				dir.y = 0;
			}
			else {
				dir.x = 0;
			}
			dir = new Vector2(Mathf.Round(dir.x), Mathf.Round(dir.y));
			if(Input.GetKey(KeyCode.Q)){
				dir = -dir;
			}
			pos = new Vector3(transform.position.x + dir.x, transform.position.y + dir.y, transform.position.z);
		}
	}
}
