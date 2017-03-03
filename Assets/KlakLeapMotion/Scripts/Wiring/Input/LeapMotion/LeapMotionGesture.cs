using UnityEngine;
using Klak.Math;

using Leap;


namespace Klak.Wiring
{
	[AddComponentMenu("Klak/Wiring/Input/LeapMotion/LeapMotion Gesture")]
	public class LeapMotionGesture : NodeBase {

		#region Editable properties
		[SerializeField]
		float multipleX = 1.0f;

		[SerializeField]
		float multipleY = 1.0f;
		#endregion

		#region Node I/O

		[SerializeField, Outlet]
		VoidEvent _swipeUpEvent = new VoidEvent();

		[SerializeField, Outlet]
		VoidEvent _swipeDownEvent = new VoidEvent();

		[SerializeField, Outlet]
		VoidEvent _swipeLeftEvent = new VoidEvent();

		[SerializeField, Outlet]
		VoidEvent _swipeRightEvent = new VoidEvent();

		[SerializeField, Outlet]
		VoidEvent _tapEvent = new VoidEvent();

//		[SerializeField, Outlet]
//		VoidEvent _waveOutEvent = new VoidEvent();
//

		[SerializeField, Outlet]
		FloatEvent _swipeXEvent = new FloatEvent();

		[SerializeField, Outlet]
		FloatEvent _swipeYEvent = new FloatEvent();

		[SerializeField, Outlet]
		Vector3Event _swipeRotateXEvent = new Vector3Event();

		[SerializeField, Outlet]
		Vector3Event _swipeRotateYEvent = new Vector3Event();
		#endregion

		#region MonoBehaviour functions


		Controller controller;
		HandModel hand_model;

		void Start () {
			controller = new Controller ();
			// スワイプのジェスチャーを有効にする
			controller.EnableGesture (Gesture.GestureType.TYPESWIPE);
			controller.EnableGesture (Gesture.GestureType.TYPEKEYTAP);
		}

		void Update () {

			Frame frame = controller.Frame ();
			GestureList leap_gestures = frame.Gestures ();

			for (int i = 0; i < leap_gestures.Count; i++) {

				Gesture gesture = leap_gestures [i];

				// ジェスチャーがスワイプだった場合
				if (gesture.Type == Gesture.GestureType.TYPESWIPE) {
					SwipeGesture Swipe = new SwipeGesture (gesture);

					// スワイプ方向
					Leap.Vector SwipeDirection = Swipe.Direction;

//					Debug.Log ("Swipe X:" + SwipeDirection.x.ToString ());
//					Debug.Log ("Swipe Y:" + SwipeDirection.x.ToString ());


					// y:0より小さかった場合
					if (SwipeDirection.y < 0) {
						// Downのログを表示
						Debug.Log ("Down");

						_swipeDownEvent.Invoke ();

					// y:0より大きかった場合
					} else if (SwipeDirection.y > 0) {
						// Upのログを表示
						Debug.Log ("Up");

						_swipeUpEvent.Invoke ();
					}

					// y:0より小さかった場合
					if (SwipeDirection.x < 0) {
						// Downのログを表示
						Debug.Log ("Left");

						_swipeLeftEvent.Invoke ();

						// y:0より大きかった場合
					} else if (SwipeDirection.x > 0) {
						// Upのログを表示
						Debug.Log ("Right");

						_swipeRightEvent.Invoke ();
					}

					_swipeXEvent.Invoke (SwipeDirection.x);
					_swipeYEvent.Invoke (SwipeDirection.y);

					_swipeRotateXEvent.Invoke (new Vector3 (0, SwipeDirection.x * multipleX, 0));
					_swipeRotateYEvent.Invoke (new Vector3 (SwipeDirection.y * multipleY, 0, 0));
				}

				if (gesture.Type == Gesture.GestureType.TYPEKEYTAP) {
					Debug.Log ("Tap!");

//					ScreenTapGesture Tap = new ScreenTapGesture (gesture);
					_tapEvent.Invoke ();
				}
			}

		}

		#endregion
	}
}