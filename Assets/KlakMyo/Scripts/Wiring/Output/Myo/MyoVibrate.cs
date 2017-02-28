using UnityEngine;
using System.Reflection;

using VibrationType = Thalmic.Myo.VibrationType;

namespace Klak.Wiring
{
	[AddComponentMenu("Klak/Wiring/Output/Myo/Myo Vibrate")]
	public class MyoVibrate : NodeBase {

		#region Editable properties
		[SerializeField]
		GameObject myo = null;

		#endregion

		#region Node I/O
		[Inlet]
		public void Vibrate()
		{
			_isVibrating = true;
		}
		#endregion

		#region Private variables

		bool _isVibrating;

		#endregion

		#region MonoBehaviour functions

		void Update () {

			ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

			if (_isVibrating) {
				thalmicMyo.Vibrate (VibrationType.Medium);
			}
		}

		#endregion
	}
}