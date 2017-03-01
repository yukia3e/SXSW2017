using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Bakery.SXSW
{
	public class SensorController : MonoBehaviour {

		#region Editable properties
		[SerializeField]
		Image _uncomfortImage;

		[SerializeField]
		Text _uncomfortText;

		[SerializeField]
		Image _heatImage;

		[SerializeField]
		Text _heatText;

		[SerializeField]
		Image _virusImage;

		[SerializeField]
		Text _virusText;

		[SerializeField]
		Image _loudImage;

		[SerializeField]
		Text _loudText;
		#endregion

		#region private properties
		private float _tempValue = 0.0f;
		private float _humValue = 0.0f;
		private float _dbValue = 0.0f;
		private float _unconfortValue = 0.0f;
		private float _heatstrokeValue = 0.0f;
		private string _virusAlert = null;

		private Color _iconColorNonActive = new Color (1f, 1f, 1f, 0.2f);
		private Color _iconColorActiveAttention = new Color (1f, 1f, 1f, 1f);
		private Color _iconColorActiveCaution = new Color (1f, 0.96f, 0.55f, 1f);
		private Color _iconColorActiveWarning = new Color (1f, 0f, 0f, 1f);

		private Dictionary<string, int> _activeEffects;
		#endregion

		#region MonoBehaviour functions
		public void updateSensor (string[] datas) {
			setSensorDatas (datas);
			judgeIndeces ();
			updateInfoCanvas ();
			emmitEffects ();
		}

		private void setSensorDatas (string[] datas) {
			_tempValue = float.Parse(datas [SensorConfig.ROW_NUM_TEMP]);
			_humValue = float.Parse(datas [SensorConfig.ROW_NUM_HUM]);
			_dbValue = float.Parse(datas [SensorConfig.ROW_NUM_DB]);
			_unconfortValue = float.Parse(datas [SensorConfig.ROW_NUM_UNCOMFORT]);
			_heatstrokeValue = float.Parse(datas [SensorConfig.ROW_NUM_HEATSTROKE]);
		}

		private void judgeIndeces () {

			_activeEffects = new Dictionary<string, int> ();

			// Unconfort index
			if (_unconfortValue > SensorConfig.LIMIT_UNCONFORT_ATTENTION) {
				_activeEffects.Add (SensorConfig.EFFECT_NAME_UNCOMFORT, SensorConfig.KBN_ATTENTION);
				_uncomfortImage.color = _iconColorActiveAttention;
			} else if (_unconfortValue > SensorConfig.LIMIT_UNCONFORT_CAUTION) {
				_activeEffects.Add (SensorConfig.EFFECT_NAME_UNCOMFORT, SensorConfig.KBN_CAUTION);
				_uncomfortImage.color = _iconColorActiveCaution;
			} else if (_unconfortValue > SensorConfig.LIMIT_UNCONFORT_WARNING) {
				_activeEffects.Add (SensorConfig.EFFECT_NAME_UNCOMFORT, SensorConfig.KBN_WARNING);
				_uncomfortImage.color = _iconColorActiveWarning;
			} else {
				_uncomfortImage.color = _iconColorNonActive;
			}

			// HeatStroke Index
			if (_heatstrokeValue > SensorConfig.LIMIT_HEAT_ATTENTION) {
				_activeEffects.Add (SensorConfig.EFFECT_NAME_HEAT, SensorConfig.KBN_ATTENTION);
				_heatImage.color = _iconColorActiveAttention;
			} else if (_heatstrokeValue > SensorConfig.LIMIT_HEAT_CAUTION) {
				_activeEffects.Add (SensorConfig.EFFECT_NAME_HEAT, SensorConfig.KBN_CAUTION);
				_heatImage.color = _iconColorActiveCaution;
			} else if (_heatstrokeValue > SensorConfig.LIMIT_HEAT_WARNING) {
				_activeEffects.Add (SensorConfig.EFFECT_NAME_HEAT, SensorConfig.KBN_WARNING);
				_heatImage.color = _iconColorActiveWarning;
			} else {
				_heatImage.color = _iconColorNonActive;
			}

			// Virus
			int virusIdx = 0;
			if (_humValue < SensorConfig.LIMIT_VIRUS_HUM) {
				virusIdx += 1;
			}
			if (_tempValue < SensorConfig.LIMIT_VIRUS_TEMP) {
				virusIdx += 1;
			}

			Debug.Log (virusIdx.ToString ());
			_virusAlert = "";
			if (virusIdx == SensorConfig.KBN_VIRUS_CAUTION) {
				_virusAlert = "MID";
				_activeEffects.Add (SensorConfig.EFFECT_NAME_VIRUS, SensorConfig.KBN_CAUTION);
				_virusImage.color = _iconColorActiveCaution;
			} else if (virusIdx == SensorConfig.KBN_VIRUS_WARNING) {
				_virusAlert = "HIGH";
				_activeEffects.Add (SensorConfig.EFFECT_NAME_VIRUS, SensorConfig.KBN_WARNING);
				_virusImage.color = _iconColorActiveWarning;
			} else {
				_virusAlert = "NONE";
				_virusImage.color = _iconColorNonActive;
			}

			// Loud
			if (_dbValue > SensorConfig.LIMIT_LOUD_ATTENTION) {
				_activeEffects.Add (SensorConfig.EFFECT_NAME_LOUD, SensorConfig.KBN_ATTENTION);
				_loudImage.color = _iconColorActiveAttention;
			} else if (_dbValue > SensorConfig.LIMIT_LOUD_CAUTION) {
				_activeEffects.Add (SensorConfig.EFFECT_NAME_LOUD, SensorConfig.KBN_CAUTION);
				_loudImage.color = _iconColorActiveCaution;
			} else if (_dbValue > SensorConfig.LIMIT_LOUD_WARNING) {
				_activeEffects.Add (SensorConfig.EFFECT_NAME_LOUD, SensorConfig.KBN_WARNING);
				_loudImage.color = _iconColorActiveWarning;
			} else {
				_loudImage.color = _iconColorNonActive;
			}
		}

		private void emmitEffects () {

			List<string> keys = new List<string> ();
			foreach (string key in _activeEffects.Keys) {
				keys.Add (key);
			}

			gameObject.GetComponent<EmissionController> ().activeEffects = keys;

			ExecuteEvents.Execute<EmissionControllerReceiver> (
				target: gameObject, 
				eventData: null, 
				functor: (reciever, eventData) => reciever.OnRecieve ()
			);
		}

		private void updateInfoCanvas () {
			_uncomfortText.text = _unconfortValue.ToString ();
			_heatText.text = _heatstrokeValue.ToString ();
			_virusText.text = _virusAlert;
			_loudText.text = _dbValue.ToString () + "dB";
		}
		#endregion
	}
}