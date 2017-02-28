using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCollision : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "Sensor") {
			other.GetComponentInChildren<PanelSlider>().SlideIn();
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "Sensor") {
			other.GetComponentInChildren<PanelSlider>().SlideOut();
		}
	}
}
