using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=Qz2qMxmtxpQ

public class PushPull : MonoBehaviour {

	public float distance = 1f;
	public LayerMask boxMask;
	GameObject box;

	void Update(){
		Physics2D.queriesStartInColliders = false;
		RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z), Vector2.right * transform.localScale.x, distance, boxMask);
		RaycastHit2D hit2 = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - .3f, transform.position.z), Vector2.right * transform.localScale.x, distance, boxMask);
		RaycastHit2D hit3 = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector2.up * transform.localScale.x, distance, boxMask);
		RaycastHit2D hit4 = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector2.down * transform.localScale.x, distance, boxMask);
		Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z), Vector2.right * transform.localScale.x, Color.red);
		Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - .3f, transform.position.z), Vector2.right * transform.localScale.x, Color.red);
		Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector2.up * transform.localScale.x, Color.red);
		Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector2.down * transform.localScale.x, Color.red);
		if(hit.collider != null && (hit.collider.gameObject.tag == "Skull" || hit.collider.gameObject.tag == "Barrel") && Input.GetKeyDown(KeyCode.Q) && hit2.collider != null && (hit2.collider.gameObject.tag == "Barrel" || hit2.collider.gameObject.tag == "Skull")){
			box = hit.collider.gameObject;
			box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
			box.GetComponent<FixedJoint2D>().enabled = true;
			box.GetComponent<BoxPull>().beingPushed = true;
		} 
		else if(Input.GetKeyUp(KeyCode.Q) && box != null){
			box.GetComponent<FixedJoint2D>().enabled = false;
			box.GetComponent<BoxPull>().beingPushed = false;
		}
		if(hit3.collider != null && (hit3.collider.gameObject.tag == "Barrel" || hit3.collider.gameObject.tag == "Skull") && Input.GetKeyDown(KeyCode.Q)){
			box = hit3.collider.gameObject;
			box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
			box.GetComponent<FixedJoint2D>().enabled = true;
			box.GetComponent<BoxPull>().beingPushed = true;
		}
		if(hit4.collider != null && (hit4.collider.gameObject.tag == "Barrel" || hit4.collider.gameObject.tag == "Skull") && Input.GetKeyDown(KeyCode.Q)){
			box = hit4.collider.gameObject;
			box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
			box.GetComponent<FixedJoint2D>().enabled = true;
			box.GetComponent<BoxPull>().beingPushed = true;
		}
	}
}
