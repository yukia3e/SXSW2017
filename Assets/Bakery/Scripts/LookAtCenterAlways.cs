using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCenterAlways : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject MainCamera = GameObject.Find("FirstPersonCharacter");
		Vector3 cameraPosition = new Vector3 (MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);

		transform.LookAt(cameraPosition);
	}
}
