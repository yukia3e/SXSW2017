using UnityEngine;
using Klak.Math;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

namespace Klak.Wiring
{
	[AddComponentMenu("Klak/Wiring/Input/Myo/Myo Gesture")]
	public class MyoGesture : NodeBase {

		#region Editable properties
		[SerializeField]
		GameObject myo = null;

		#endregion

		#region Node I/O

		[SerializeField, Outlet]
		VoidEvent _waveInEvent = new VoidEvent();

		[SerializeField, Outlet]
		VoidEvent _waveOutEvent = new VoidEvent();

		[SerializeField, Outlet]
		VoidEvent _doubleTapEvent = new VoidEvent();

		[SerializeField, Outlet]
		VoidEvent _fistEvent = new VoidEvent();

		[SerializeField, Outlet]
		VoidEvent _fingersSpreadEvent = new VoidEvent();

		#endregion

		#region MonoBehaviour functions

//		public Material waveInMaterial;
//		public Material waveOutMaterial;
//		public Material doubleTapMaterial;
//
		private Pose _lastPose = Pose.Unknown;

		// Update is called once per frame
		void Update () {
			ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

			if (thalmicMyo.pose != _lastPose) {
				_lastPose = thalmicMyo.pose;

				if (thalmicMyo.pose == Pose.WaveIn) {

					_waveInEvent.Invoke();
					ExtendUnlockAndNotifyUserAction (thalmicMyo);

				} else if (thalmicMyo.pose == Pose.WaveOut) {

					_waveOutEvent.Invoke();
					ExtendUnlockAndNotifyUserAction (thalmicMyo);

				} else if (thalmicMyo.pose == Pose.DoubleTap) {

					_doubleTapEvent.Invoke();
					ExtendUnlockAndNotifyUserAction (thalmicMyo);

				} else if (thalmicMyo.pose == Pose.Fist) {

					_fistEvent.Invoke();
					ExtendUnlockAndNotifyUserAction (thalmicMyo);

				} else if (thalmicMyo.pose == Pose.FingersSpread) {

					_fingersSpreadEvent.Invoke();
					ExtendUnlockAndNotifyUserAction (thalmicMyo);
				}
			}
		}

		void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
		{
			ThalmicHub hub = ThalmicHub.instance;

			if (hub.lockingPolicy == LockingPolicy.Standard) {
				myo.Unlock (UnlockType.Timed);
			}

			myo.NotifyUserAction ();
		}

		#endregion
	}
}
