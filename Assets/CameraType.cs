using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraType : MonoBehaviour {

	public enum CamType {ZoomIn, ZoomOut};
	public CamType type = CamType.ZoomIn;
}
