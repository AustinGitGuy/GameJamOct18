using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//stores and manages player info
namespace Managers{
	public class PlayerManager : Singleton<PlayerManager> {

		public int totalCollectedCoins = 0;
		public int totalRings = 0;
		public int totalSkulls = 0;
		public int health;
		GameObject playerObject;
		[SerializeField]
		float timerDecrease;
		[SerializeField] 
		Shader dissolve;
		[SerializeField]
		Shader diffuse;
		[SerializeField]
		Texture noiseText;
		Renderer playerRend;

		float dissolveTimer = 0;

		public bool isDissolving;
		bool doneDissolving;
		GameObject[] points;

		void Start(){
			health = 5;
			playerObject = GetPlayer();
			playerRend = playerObject.GetComponent<Renderer>();
			OnSceneChange();
		}

		public void OnSceneChange(){
			points = GameObject.FindGameObjectsWithTag("CameraPoint");
		}

        void Update(){
			if(doneDissolving){
				StartCoroutine(Reform());
			}
            Managers.GameManager.Instance.updateCamera(transform.position);
		}

        void updateCamera()
        {
            Managers.GameManager.Instance.updateCamera(transform.position);
        }
		public void CoinCollected(int coinValue){
			totalCollectedCoins += coinValue;
		}

		public void RingCollected(int rings){
			totalRings += rings;
		}
        
        public void resetPlayerPosition()
        {
            transform.position = Vector3.zero;
        }
		public void SkullCollected(int skulls){
			totalSkulls += skulls;
		}

		public void HealthMod(int mod){
			health += mod;
		}

		public GameObject GetPlayer(){
			if(playerObject == null){
				playerObject = GameObject.Find("Player");
			}
			return playerObject;
		}

		public IEnumerator DissolvePlayer(){
			isDissolving = true;
			playerRend.material.shader = dissolve;
			playerRend.material.SetTexture("_NoiseTex", noiseText);
			dissolveTimer = 0;
			while(dissolveTimer < 1){
				playerRend.material.SetFloat("_Level", dissolveTimer);
				dissolveTimer += .02f;
				yield return new WaitForSeconds(.04f);
			}
			doneDissolving = true;
			playerObject.transform.position = GetClosestPoint(points).gameObject.GetComponent<CameraType>().safeSpot.position;
		}

		IEnumerator Reform(){
			doneDissolving = false;
			dissolveTimer = 1;
			while(dissolveTimer > 0){
				playerRend.material.SetFloat("_Level", dissolveTimer);
				dissolveTimer -= .02f;
				yield return new WaitForSeconds(.04f);
			}
			isDissolving = false;
			playerRend.material.shader = diffuse;
			Managers.TimeManager.Instance.timeLeft -= timerDecrease;
			health--;
			if(health <= 0){
				Debug.Log("Game over");
				//Game over
			}
		}

        public string getTileName()
        {
            Vector3Int tilePosit = new Vector3Int((int)transform.position.x , (int)transform.position.y, (int)transform.position.z);
            Tile tile = (Tile)Managers.GameManager.Instance.getGroundTileMap().GetTile(tilePosit);
            if (tile)
            {
                return tile.name;
            }
            return "none";
        }

			//https://forum.unity.com/threads/clean-est-way-to-find-nearest-object-of-many-c.44315/
		Transform GetClosestPoint(GameObject[] points){
    		Transform tMin = null;
    		float minDist = Mathf.Infinity;
    		Vector3 currentPos = playerObject.transform.position;
    		foreach(GameObject t in points){
        		float dist = Vector3.Distance(t.transform.position, currentPos);
        		if(dist < minDist && t.GetComponent<CameraType>().type == CameraType.CamType.ZoomIn){
            		tMin = t.transform;
            		minDist = dist;
        		}
    		}
    		return tMin;
		}
	}
}
