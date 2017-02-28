using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtCenter : MonoBehaviour {

	public Transform targetTransform; 
	public Transform cameraTransform; 

	// Use this for initialization
	void Update () {
		targetTransform.LookAt (cameraTransform.position);
	}
}
