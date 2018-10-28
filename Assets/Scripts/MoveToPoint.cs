using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour {

	GameObject[] points;
	GameObject player;
	Camera cam;

	void Start(){
		cam = GetComponent<Camera>();
		player = Managers.PlayerManager.Instance.GetPlayer();
		points = GameObject.FindGameObjectsWithTag("CameraPoint");
	}

	void Update(){
		Transform closest = GetClosestPoint(points);
		CameraType.CamType newType = closest.gameObject.GetComponent<CameraType>().type;
		Vector3 newPos = closest.position;
		if(newPos != transform.position){
			if(newType == CameraType.CamType.ZoomIn){
				StartMove(newPos, true);
			}
			else {
				StartMove(newPos, false);
			}
		}
	}

	void StartMove(Vector3 newPos, bool zoomIn){
		if(zoomIn){
			cam.orthographicSize = 5;
			transform.position = new Vector3(newPos.x, newPos.y, -10);
		}
		else {
			cam.orthographicSize = 10;
			transform.position = new Vector3(newPos.x, newPos.y, -10);
		}
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
