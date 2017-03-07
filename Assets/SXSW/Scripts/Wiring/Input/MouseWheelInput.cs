using UnityEngine;
using Klak.Math;

namespace Klak.Wiring
{
	[AddComponentMenu("Klak/Wiring/Input/Mouse Wheel Input")]
	public class MouseWheelInput : NodeBase {

		#region Editable properties

		[SerializeField]
		KeyCode _keyCode = KeyCode.Space;

		[SerializeField]
		float _offValue = 0.0f;

		[SerializeField]
		float _onValue = 1.0f;

		[SerializeField]
		FloatInterpolator.Config _interpolator;

		#endregion

		#region Node I/O

		[SerializeField, Outlet]
		VoidEvent _upEvent = new VoidEvent();

		[SerializeField, Outlet]
		VoidEvent _downEvent = new VoidEvent();

		[SerializeField, Outlet]
		FloatEvent _valueEvent = new FloatEvent();

		#endregion

		#region MonoBehaviour functions

		FloatInterpolator _floatValue;

		void Start()
		{
			_floatValue = new FloatInterpolator(0, _interpolator);
		}

		void Update()
		{
			if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
				_upEvent.Invoke();
				_floatValue.targetValue = _onValue;
			}

			if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
				_downEvent.Invoke();
				_floatValue.targetValue = _onValue;
			}

			_valueEvent.Invoke(_floatValue.Step());
		}

		#endregion
	}
}