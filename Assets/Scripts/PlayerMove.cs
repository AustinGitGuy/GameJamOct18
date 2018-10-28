using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls player movement and collisions

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

    ParticleSystem system;

	void Start(){
        system = transform.Find("Effects").GetComponent<ParticleSystem>();
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
        if(Managers.PlayerManager.Instance.isDissolving){
            rb.velocity = Vector3.zero;
            return;
        }
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
            ParticleSystem.MainModule main = system.main;
            main.startColor = Color.blue;
            system.Play();
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Skull"){
            ParticleSystem.MainModule main = system.main;
            main.startColor = Color.black;
            system.Play();
            Managers.PlayerManager.Instance.SkullCollected(1);
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Ring"){
            ParticleSystem.MainModule main = system.main;
            main.startColor = Color.yellow;
            system.Play();
            Managers.PlayerManager.Instance.RingCollected(1);
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Coin"){
            ParticleSystem.MainModule main = system.main;
            main.startColor = Color.yellow;
            system.Play();
            Managers.PlayerManager.Instance.CoinCollected(1);
            Destroy(col.gameObject);
        }
    }
}
