using UnityEngine;

namespace Klak.Wiring
{
	[AddComponentMenu("Klak/Wiring/Output/Component/Transform Out2")]
	public class TransformOut2 : NodeBase
	{
		#region Editable properties

		[SerializeField]
		Transform _targetTransform;

		[SerializeField]
		bool _addToOriginal = true;

		#endregion

		#region Node I/O

		[Inlet]
		public Vector3 position {
			set {
				if (!enabled || _targetTransform == null) return;
				_targetTransform.localPosition =
					_addToOriginal ? _originalPosition + value : value;
				_originalPosition = _originalPosition + value;
			}
		}

		[Inlet]
		public Quaternion rotation {
			set {
				if (!enabled || _targetTransform == null) return;
				_targetTransform.localRotation =
					_addToOriginal ? _originalRotation * value : value;
				_originalRotation = _originalRotation * value;
			}
		}

		[Inlet]
		public Vector3 scale {
			set {
				if (!enabled || _targetTransform == null) return;
				_targetTransform.localScale =
					_addToOriginal ? _originalScale + value : value;
				_originalScale = _originalScale + value;
			}
		}

		[Inlet]
		public float uniformScale {
			set {
				if (!enabled || _targetTransform == null) return;
				var s = Vector3.one * value;
				if (_addToOriginal) s += _originalScale;
				_targetTransform.localScale = s;
			}
		}

		#endregion

		#region Private members

		Vector3 _originalPosition;
		Quaternion _originalRotation;
		Vector3 _originalScale;

		void OnEnable()
		{
			if (_targetTransform != null)
			{
				_originalPosition = _targetTransform.localPosition;
				_originalRotation = _targetTransform.localRotation;
				_originalScale = _targetTransform.localScale;
			}
		}

		void OnDisable()
		{
			if (_targetTransform != null)
			{
				_targetTransform.localPosition = _originalPosition;
				_targetTransform.localRotation = _originalRotation;
				_targetTransform.localScale = _originalScale;
			}
		}

		#endregion
	}
}
