using UnityEngine;
using System.Collections.Generic;

namespace Klak.Wiring
{
	[AddComponentMenu("Klak/Wiring/Input/ObjectForward")]
	public class ObjectForward : NodeBase
	{
		#region Editable properties
		[SerializeField]
		GameObject _target;

		[SerializeField]
		GameObject _eyeDetect;
		#endregion

		#region Node I/O
		[Inlet]
		public float input {
			set {
				Vector3 direction = transform.TransformPoint(_eyeDetect.transform.forward) * value;
				_target.transform.Translate (direction.x, 0.0f, direction.z, Space.World);
			}
		}
		#endregion

		#region MonoBehaviour functions

		#endregion
	}
}
