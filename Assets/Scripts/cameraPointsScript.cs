using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cameraPointsScript : MonoBehaviour
{
    [System.Serializable]
    struct locs
    {
        [SerializeField]
        public GameObject TopLeftCorner;
        [SerializeField]
        public GameObject BottomRightCorner;
        public Vector2 center;
    }
    [SerializeField]
    locs[] cameraLocs;
    GameObject topLeftCorner;
    GameObject botRightCorner;
    int roomIndex;
    int prevRoomIndex;
    private void Awake()
    {
        initCenter();
    }
    public void initCenter()
    {
        for (int i = 0; i < cameraLocs.Length; i++)
        {
            cameraLocs[i].center = new Vector2(
                avg(cameraLocs[i].TopLeftCorner.transform.position.x, cameraLocs[i].BottomRightCorner.transform.position.x),
                avg(cameraLocs[i].TopLeftCorner.transform.position.y, cameraLocs[i].BottomRightCorner.transform.position.y)
                );
        }
    }

    //just a helper function to make initCenter() a little more clear.
    private float avg(float x, float y)
    {
        return (x + y) / 2.0f;
    }
    public GameObject getTopLeft(int roomID)
    {
        return topLeftCorner;
    }
    public GameObject getBotRight(int roomID)
    {
        return botRightCorner;
    }


    public void setRoomPosition(Vector2 playerLoc)
    {
        Vector2 botRight, topLeft;
        //==Get the closest rooms==/
        int index = 0;
        float minDistance = -1;
        float minDistanceTwo = -1;
        int minIndex = -1;
        int minIndexTwo = -1;
        float tempDist;
        foreach (locs loc in cameraLocs)
        {
            tempDist = (loc.center - playerLoc).magnitude;
            if (minDistance > tempDist)
            {
                //update second minimum
                minIndexTwo = minIndex;
                minDistanceTwo = minDistance;
                //update minimum
                minIndex = index;
                minDistance = tempDist;
            }
            else if (minDistanceTwo > tempDist)
            {
                minIndexTwo = index;
                minDistanceTwo = tempDist;
            }
            index++;
        }
        //minIndex
        //minIndexTwo

        //if player is in one or both of these then perfect. if not, problem.

        index = -1;
        botRight = cameraLocs[minIndex].BottomRightCorner.transform.position;
        topLeft = cameraLocs[minIndex].TopLeftCorner.transform.position;
        if (playerLoc.x < botRight.x
            && playerLoc.x > topLeft.x
            && playerLoc.y < topLeft.y
            && playerLoc.y > botRight.y)
        {
            index = minIndex;
        }
        if (index == -1)
        {
            botRight = cameraLocs[minIndexTwo].BottomRightCorner.transform.position;
            topLeft = cameraLocs[minIndexTwo].TopLeftCorner.transform.position;
            if (playerLoc.x < botRight.x
                && playerLoc.x > topLeft.x
                && playerLoc.y < topLeft.y
                && playerLoc.y > botRight.y)
            {
                index = minIndexTwo;
            }
        }
        if(index == -1)
        {

        }

        //Get which room a player is in by loc
        //figure out if a player is in between rooms

    }
}
