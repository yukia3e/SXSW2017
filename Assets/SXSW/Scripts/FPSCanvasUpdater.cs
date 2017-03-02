using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace Bakery.SXSW
{
	public class FPSCanvasUpdater : MonoBehaviour, FPSCanvasUpdaterReceiver {

		#region Editable properties
		[SerializeField]
		Text _infoCanvas;

		[SerializeField]
		ScrollRect _scrollRect;
		#endregion

		List<string> _lines = new List<string>();
		public List<string> lines {
			get { return _lines; }
			set { _lines = value; }
		}

		#region MonoBehaviour functions
		public void OnRecieve() {
			StartCoroutine(loop());
		}

		private IEnumerator loop() {
			_infoCanvas.text = "";
			foreach (string line in _lines) {
				_infoCanvas.text += line;
				_scrollRect.verticalNormalizedPosition = 0f;
				yield return new WaitForSeconds (0.0001f);
			}
		}
		#endregion
	}
}