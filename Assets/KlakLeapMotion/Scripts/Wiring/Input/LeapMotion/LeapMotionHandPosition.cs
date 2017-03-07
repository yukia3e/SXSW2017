using UnityEngine;
using Klak.Math;

using Leap;


namespace Klak.Wiring
{
	[AddComponentMenu("Klak/Wiring/Input/LeapMotion/LeapMotion Hand Position")]
	public class LeapMotionHandPosition : NodeBase {

		#region Editable properties
		[SerializeField]
		float _z = -10.0f;
		#endregion

		#region Node I/O
		[SerializeField, Outlet]
		FloatEvent _handPositionXEvent = new FloatEvent();

		[SerializeField, Outlet]
		FloatEvent _handPositionYEvent = new FloatEvent();

		[SerializeField, Outlet]
		FloatEvent _handPositionZEvent = new FloatEvent();

		#endregion

		#region MonoBehaviour functions
		Controller controller;
		Hand hand;

		void Start () {
			controller = new Controller ();
		}
		
		void Update () {

			Frame frame = controller.Frame ();
			HandList hands = frame.Hands;

			if (hands.Count > 0) {
				hand = hands.Rightmost;
//				Debug.Log ("x:" + hand.PalmPosition.x + ", y:" + hand.PalmPosition.y + ", z:" + hand.PalmPosition.z);

				_handPositionXEvent.Invoke (hand.PalmPosition.x);
				_handPositionYEvent.Invoke (hand.PalmPosition.y);
				_handPositionZEvent.Invoke (hand.PalmPosition.z);
			}
		}
		#endregion
	}
}