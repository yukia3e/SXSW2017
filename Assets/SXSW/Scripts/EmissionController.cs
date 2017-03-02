using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ParticlePlayground;

namespace Bakery.SXSW
{
	public class EmissionController : MonoBehaviour, EmissionControllerReceiver {

		#region Editable properties
		[SerializeField]
		PlaygroundParticlesC _playground;

		List<string> _activeEffects;
		public List<string> activeEffects {
			get { return _activeEffects; }
			set { _activeEffects = value; }
		}
		#endregion

		bool isRunning = false;
		Coroutine coroutine;

		#region MonoBehaviour functions
		public void OnRecieve() {
			if (isRunning) {
				StopCoroutine (coroutine);
				isRunning = false;
			}

			int effectCount = _activeEffects.Count;
			if (effectCount == 0) {
				_activeEffects.Clear ();
				_playground.gameObject.SetActive (false);
			} else {
				coroutine = StartCoroutine (loop (effectCount));
			}
		}

		private IEnumerator loop(int effectCount) {
			isRunning = true;
			_playground.gameObject.SetActive (true);
			int counta = 0;
			while (true) {
				_playground.Load (_activeEffects [counta]);
				yield return new WaitForSeconds (5f);
				counta++;
				if (counta == effectCount) {
					counta = 0;
				}
			}
		}
		#endregion
	}
}
