using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour {

	GameObject[] points;
	GameObject player;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
		points = GameObject.FindGameObjectsWithTag("CameraPoint");
	}

	void Update(){
		Vector3 newPos = GetClosestPoint(points).position;
		transform.position = new Vector3(newPos.x, newPos.y, -10);
	}
	
	//https://forum.unity.com/threads/clean-est-way-to-find-nearest-object-of-many-c.44315/
	Transform GetClosestPoint(GameObject[] points){
    	Transform tMin = null;
    	float minDist = Mathf.Infinity;
    	Vector3 currentPos = player.transform.position;
    	foreach (GameObject t in points){
        	float dist = Vector3.Distance(t.transform.position, currentPos);
        	if(dist < minDist){
            	tMin = t.transform;
            	minDist = dist;
        	}
    	}
    	return tMin;
	}
}
