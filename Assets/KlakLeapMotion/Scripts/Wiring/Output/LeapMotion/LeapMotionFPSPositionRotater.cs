using UnityEngine;
using System.Reflection;

namespace Klak.Wiring
{
	[AddComponentMenu("Klak/Wiring/Output/LeapMotion/LeapMotion FPS Position Rotator")]
	public class LeapMotionFPSPositionRotater : NodeBase {

		#region Editable properties
		[SerializeField]
		Transform  _target;

		[SerializeField]
		float _right = 20.0f;

		[SerializeField]
		float _left = -20.0f;

		[SerializeField]
		float _rotateSpeed = 40f;
		#endregion


		#region Node I/O
		[Inlet]
		public float input {
			set {
				if (!enabled || _target == null) return;

				if (value < _left) {
					_target.transform.Rotate (new Vector3 (0f, - _rotateSpeed * Time.deltaTime, 0f));
				}

				if (value > _right) {
					_target.transform.Rotate (new Vector3 (0f, _rotateSpeed * Time.deltaTime, 0f));
				}

			}
		}
		#endregion

		#region Private variables

		#endregion

		#region MonoBehaviour functions

		#endregion
	}
}
