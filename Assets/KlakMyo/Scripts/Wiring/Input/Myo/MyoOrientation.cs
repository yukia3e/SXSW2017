using UnityEngine;
using Klak.Math;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

namespace Klak.Wiring
{
	[AddComponentMenu("Klak/Wiring/Input/Myo/Myo Orientation")]
	public class MyoOrientation : NodeBase {

		#region Editable properties
		[SerializeField]
		GameObject myo = null;

		[SerializeField]
		FloatInterpolator.Config _interpolator;
		#endregion

		#region Node I/O

		[SerializeField, Inlet]
		public void updateReference()
		{
			_updateReference = true;
		}


		[SerializeField, Outlet]
		FloatEvent _xEvent = new FloatEvent();

		[SerializeField, Outlet]
		FloatEvent _yEvent = new FloatEvent();

		[SerializeField, Outlet]
		FloatEvent _zEvent = new FloatEvent();

		[SerializeField, Outlet]
		Vector3Event _outputWithoutYEvent = new Vector3Event();

		#endregion

		#region MonoBehaviour functions
		Quaternion _antiYaw = Quaternion.identity;
		float _referenceRoll = 0.0f;
		bool _updateReference = false;

		void Update () {

			// MyoオブジェクトにアタッチされたThalmicMyoコンポーネントにアクセスします。
			ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

			// 参照を更新する。これは、Myoアームバンドがこれらの参照が取られたときと同じ方向に向いているとき、
			// 視聴者から前方に向くようにジョイントを画面上に固定する。
			if (_updateReference) {
				
				// _antiYawは、着用者の腕が基準方向を指しているとき、回転の前方ベクトルをZ = 1に整列させる
				// Y軸（上）についてのMyo腕バンドの回転を表す。
				_antiYaw = Quaternion.FromToRotation (
					new Vector3 (myo.transform.forward.x, 0, myo.transform.forward.z),
					new Vector3 (0, 0, 1)
				);

				// _referenceRollは、Myoアームバンドが基準ゼロロール方向から前方軸（手に向かって腕を下に向けて見たとき）を
				// 時計回りに何度回転させたかを表し、この方向を計算して説明します。
				// この基準をとると、ジョイントは、ロール値が基準に一致したときに
				// 上向きになるように、その前軸の周りを回転します。
				Vector3 referenceZeroRoll = computeZeroRollVector (myo.transform.forward);
				_referenceRoll = rollFromZero (referenceZeroRoll, myo.transform.forward, myo.transform.up);

				_updateReference = false;
			}

			// 現在のゼロロールベクトルとロール値。
			Vector3 zeroRoll = computeZeroRollVector (myo.transform.forward);
			float roll = rollFromZero (zeroRoll, myo.transform.forward, myo.transform.up);

			Quaternion rot;

			// 相対ロールは、現在のロールが基準ロールに対してどれだけ変化したかを単純に表したものです。
			// adjustAngleは結果値を-180〜180度の範囲内に保ちます。
			float relativeRoll = normalizeAngle (roll - _referenceRoll);

			// antiRollは、myo Armbandの前方軸回りの回転を表し、参照ロール用に調整されます。
			Quaternion antiRoll = Quaternion.AngleAxis (relativeRoll, myo.transform.forward);

			// ここでアンチロールとヨーの回転はMyoアームバンドの順方向に加えられて
			// ジョイントの向きが得られます。
			rot = _antiYaw * antiRoll * Quaternion.LookRotation (myo.transform.forward);

			// 上記の計算はMyoアームバンドの+ x方向をそれ自身の座標系で仮定して行い、
			// 着用者の肘に向かっていた。ミオアームバンドが+ x方向を反対にして装着されている場合、
			// 補正するために回転を更新する必要があります。.
			if (thalmicMyo.xDirection == Thalmic.Myo.XDirection.TowardWrist) {
				rot = new Quaternion(rot.x,
					-rot.y,
					rot.z,
					-rot.w);
			}
				
			// z軸の回転をoff
			rot.z = 0.0f;

			_outputWithoutYEvent.Invoke(rot.eulerAngles);

			_xEvent.Invoke(rot.eulerAngles.x);
			_yEvent.Invoke(rot.eulerAngles.y);
			_zEvent.Invoke(rot.eulerAngles.z);
		}

		float rollFromZero (Vector3 zeroRoll, Vector3 forward, Vector3 up)
		{
			float cosine = Vector3.Dot (up, zeroRoll);

			Vector3 cp = Vector3.Cross (up, zeroRoll);
			float directionCosine = Vector3.Dot (forward, cp);
			float sign = directionCosine < 0.0f ? 1.0f : -1.0f;

			return sign * Mathf.Rad2Deg * Mathf.Acos (cosine);
		}

		Vector3 computeZeroRollVector (Vector3 forward)
		{
			Vector3 antigravity = Vector3.up;
			Vector3 m = Vector3.Cross (myo.transform.forward, antigravity);
			Vector3 roll = Vector3.Cross (m, myo.transform.forward);
			return roll.normalized;
		}

		float normalizeAngle (float angle)
		{
			if (angle > 180.0f) {
				return angle - 360.0f;
			}
			if (angle < -180.0f) {
				return angle + 360.0f;
			}
			return angle;
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