using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Holds points for each room in the scene used for camera adjustment, and room re-setting.
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
    [System.Serializable]
    struct ObjectToReset
    {
        public GameObject gObject;
        public Vector2 startPosit;
        public int roomID;
    }
    [SerializeField]
    locs[] cameraLocs;
    [SerializeField]
    List<ObjectToReset> objectsToReset;
    GameObject topLeftCorner;
    GameObject botRightCorner;
    int roomIndex;
    int prevRoomIndex;
    private void Awake()
    {
        initCenter();
    }
    private void Start()
    {
        objectsToReset = new List<ObjectToReset>();
        setUpObjectsInRooms();
        //pass camera script to game manager
        Managers.GameManager.Instance.LoadedNewCameraLevel(this);
    }

    //reset objects to original position. Call this when the player is teleported?
    public void resetObjectsInRoom(int roomID)
    {
        ObjectToReset obj;
        for(int i = 0; i < objectsToReset.Count; i++)
        {
            obj = objectsToReset[i];
            if(obj.roomID == i)
            {
                obj.gObject.transform.position = obj.startPosit;
            }
        }
    }
    //add all objects to objectsToRest with correct room index.
    private void setUpObjectsInRooms()
    {
        objectsToReset.Clear();
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        int index = 0;
        foreach(locs loc in cameraLocs)
        {
            Vector2 topLeft = loc.TopLeftCorner.transform.position;
            Vector2 botRight = loc.BottomRightCorner.transform.position;
            foreach(GameObject gb in allObjects)
            {
                if(gb.scene == gameObject.scene) //ignore objects outside this scene
                {
                    Vector2 gbPosit = gb.transform.position;
                    if (gbPosit.x < botRight.x
                    &&  gbPosit.x > topLeft.x
                    &&  gbPosit.y < topLeft.y
                    &&  gbPosit.y > botRight.y)
                    {
                        ObjectToReset obj;
                        obj.gObject = gb;
                        obj.roomID = index;
                        obj.startPosit = gb.transform.position;
                        objectsToReset.Add(obj);
                    }
                }
            }
            

            index++;
        }
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
    public Vector2 getTopLeft()
    {
        return topLeftCorner.transform.position;
    }
    public Vector2 getBotRight()
    {
        return botRightCorner.transform.position;
    }


    public void setRoomPosition(Vector2 playerLoc)
    {
        Vector2 botRight, topLeft;
        //==Get the closest rooms==/
        int index = 0;
        float minDistance = float.MaxValue;
        float minDistanceTwo = float.MaxValue;
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
            index = roomIndex;
        }
        else
        {
            prevRoomIndex = roomIndex;
            roomIndex = index;
        }

        botRightCorner = cameraLocs[index].BottomRightCorner;
        topLeftCorner = cameraLocs[index].TopLeftCorner;

    }

    public int getRoomIndex()
    {
        return roomIndex;
    }
    public int getPrevRoomIndex()
    {
        return prevRoomIndex;
    }
}
