using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    SpriteRenderer render;

    Rigidbody2D rb;
    float xMove, yMove;
    float moveMod = 5f;

    [SerializeField]
    Sprite forwardSprite;
    [SerializeField]
    Sprite backwardsSprite;
    [SerializeField]
    Sprite sideSprite;

	void Start(){
        render = GetComponent<SpriteRenderer>();
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
        if(Mathf.Abs(xMove) > Mathf.Abs(yMove)){
            if(render.sprite != sideSprite){
                render.sprite = sideSprite;
            }
            if(xMove > 0){
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if(xMove < 0){
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else {
            if(yMove > 0 && render.sprite != backwardsSprite){
                render.sprite = backwardsSprite;
            }
            if(yMove < 0 && render.sprite != forwardSprite){
                render.sprite = forwardSprite;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "WaterVase"){
            moveMod++;
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Skull"){
            Managers.PlayerManager.Instance.SkullCollected(1);
            Destroy(col.gameObject);
        }
    }
}
