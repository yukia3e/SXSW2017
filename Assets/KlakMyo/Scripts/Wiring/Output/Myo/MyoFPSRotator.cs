using UnityEngine;
using System.Reflection;

namespace Klak.Wiring
{
	[AddComponentMenu("Klak/Wiring/Output/Myo/Myo FPS Rotator")]
	public class MyoFPSRotator : NodeBase {

		#region Editable properties
        [SerializeField]
		Transform  _target;

        [SerializeField]
        float _right = 45.0f;

		[SerializeField]
		float _left = 45.0f;

		[SerializeField]
		float _rotateSpeed = 40f;
		#endregion

		#region Node I/O
		[Inlet]
		public float input {
            set {
                if (!enabled || _target == null) return;

				if (value > _right && value < 180.0f) {
					_target.transform.Rotate (new Vector3 (0f, _rotateSpeed * Time.deltaTime, 0f));
				}
					
				if (value >= 180.0f && value < 360.0f - _left) {
					_target.transform.Rotate (new Vector3 (0f, -_rotateSpeed * Time.deltaTime, 0f));
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