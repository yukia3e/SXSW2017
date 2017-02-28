using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSlider : MonoBehaviour {

	public AnimationCurve animCurve = AnimationCurve.Linear (0, 0, 1, 1);
	public Vector3 inPosition;
	public Vector3 outPosition;
	public GameObject panel;
	public float duration = 1.0f;
	public Graphic[] uiElements;

	public void SlideIn() {
		StartCoroutine (StartSlidePanel (true));
	}

	public void SlideOut() {
		StartCoroutine (StartSlidePanel (false));
	}

	private IEnumerator StartSlidePanel(bool isSlideIn){
		Vector3 startPos = transform.localPosition;
		Vector3 moveDistance;

		if (isSlideIn) {
			panel.SetActive (true);

			moveDistance = (inPosition - startPos);

			foreach (Graphic element in uiElements) {
				element.CrossFadeAlpha (1f, duration, false);
			}
		} else {
			moveDistance = (outPosition - startPos);

			foreach (Graphic element in uiElements) {
				element.CrossFadeAlpha (0f, duration, false);
			}
		}

		float startTime = Time.time;

		while ((Time.time - startTime) < duration) {
			transform.localPosition = startPos + moveDistance * animCurve.Evaluate (Time.time - startTime / duration);
			yield return 0;
		}
		transform.localPosition = startPos + moveDistance;

		if (!isSlideIn) {
			panel.SetActive (false);
		}
	}
}
