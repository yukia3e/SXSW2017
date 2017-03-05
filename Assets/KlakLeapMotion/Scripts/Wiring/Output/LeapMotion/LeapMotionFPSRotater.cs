using UnityEngine;
using System.Reflection;

namespace Klak.Wiring
{
	[AddComponentMenu("Klak/Wiring/Output/LeapMotion/LeapMotion FPS Rotator")]
	public class LeapMotionFPSRotater : NodeBase {

		#region Editable properties
		[SerializeField]
		Transform  _target;

		[SerializeField]
		float _rotateSpeed = 40f;
		#endregion

		#region Node I/O
		[Inlet]
		public float rotateLeft {
			set {
				_target.Rotate (0f, - value * _rotateSpeed * Time.deltaTime, 0f);
			}
		}

		[Inlet]
		public float rotateRight {
			set {
				_target.Rotate (0f, value * _rotateSpeed * Time.deltaTime, 0f);
			}
		}
		#endregion

		#region Private variables

		#endregion

		#region MonoBehaviour functions

		#endregion
	}
}