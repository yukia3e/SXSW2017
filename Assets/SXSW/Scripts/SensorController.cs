using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

		private Color _iconColorNonActive = new Color (255f, 255f, 255f, 50f);
		private Color _iconColorActiveAttention = new Color (255f, 255f, 255f, 255f);
		private Color _iconColorActiveCaution = new Color (255f, 247f, 141f, 255f);
		private Color _iconColorActiveWarning = new Color (255f, 0f, 0f, 255f);

		private Dictionary<string, int> activeEffects;
		#endregion

		#region MonoBehaviour functions
		public void updateSensor (string[] datas) {
			setSensorDatas (datas);
			judgeIndeces ();
			emmitEffects ();
			updateInfoCanvas ();
		}

		private void setSensorDatas (string[] datas) {
			_tempValue = float.Parse(datas [SensorConfig.ROW_NUM_TEMP]);
			_humValue = float.Parse(datas [SensorConfig.ROW_NUM_HUM]);
			_dbValue = float.Parse(datas [SensorConfig.ROW_NUM_DB]);
			_unconfortValue = float.Parse(datas [SensorConfig.ROW_NUM_UNCOMFORT]);
			_heatstrokeValue = float.Parse(datas [SensorConfig.ROW_NUM_HEATSTROKE]);
		}

		private void judgeIndeces () {

			activeEffects = new Dictionary<string, int> ();

			// Unconfort index
			if (_unconfortValue > SensorConfig.LIMIT_UNCONFORT_ATTENTION) {
				activeEffects.Add (SensorConfig.EFFECT_NAME_UNCOMFORT, SensorConfig.KBN_ATTENTION);
				_uncomfortImage.color = _iconColorActiveAttention;
			} else if (_unconfortValue > SensorConfig.LIMIT_UNCONFORT_CAUTION) {
				activeEffects.Add (SensorConfig.EFFECT_NAME_UNCOMFORT, SensorConfig.KBN_CAUTION);
				_uncomfortImage.color = _iconColorActiveCaution;
			} else if (_unconfortValue > SensorConfig.LIMIT_UNCONFORT_WARNING) {
				activeEffects.Add (SensorConfig.EFFECT_NAME_UNCOMFORT, SensorConfig.KBN_WARNING);
				_uncomfortImage.color = _iconColorActiveWarning;
			} else {
				_uncomfortImage.color = _iconColorNonActive;
			}

			// HeatStroke Index
			if (_heatstrokeValue > SensorConfig.LIMIT_HEAT_ATTENTION) {
				activeEffects.Add (SensorConfig.EFFECT_NAME_HEAT, SensorConfig.KBN_ATTENTION);
				_heatImage.color = _iconColorActiveAttention;
			} else if (_heatstrokeValue > SensorConfig.LIMIT_HEAT_CAUTION) {
				activeEffects.Add (SensorConfig.EFFECT_NAME_HEAT, SensorConfig.KBN_CAUTION);
				_heatImage.color = _iconColorActiveCaution;
			} else if (_heatstrokeValue > SensorConfig.LIMIT_HEAT_WARNING) {
				activeEffects.Add (SensorConfig.EFFECT_NAME_HEAT, SensorConfig.KBN_WARNING);
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
				activeEffects.Add (SensorConfig.EFFECT_NAME_VIRUS, SensorConfig.KBN_CAUTION);
				_virusImage.color = _iconColorActiveCaution;
			} else if (virusIdx == SensorConfig.KBN_VIRUS_WARNING) {
				_virusAlert = "HIGH";
				activeEffects.Add (SensorConfig.EFFECT_NAME_VIRUS, SensorConfig.KBN_WARNING);
				_virusImage.color = _iconColorActiveWarning;
			} else {
				_virusAlert = "NONE";
				_virusImage.color = _iconColorNonActive;
			}

			// Loud
			if (_dbValue > SensorConfig.LIMIT_LOUD_ATTENTION) {
				activeEffects.Add (SensorConfig.EFFECT_NAME_LOUD, SensorConfig.KBN_ATTENTION);
				_loudImage.color = _iconColorActiveAttention;
			} else if (_dbValue > SensorConfig.LIMIT_LOUD_CAUTION) {
				activeEffects.Add (SensorConfig.EFFECT_NAME_LOUD, SensorConfig.KBN_CAUTION);
				_loudImage.color = _iconColorActiveCaution;
			} else if (_dbValue > SensorConfig.LIMIT_LOUD_WARNING) {
				activeEffects.Add (SensorConfig.EFFECT_NAME_LOUD, SensorConfig.KBN_WARNING);
				_loudImage.color = _iconColorActiveWarning;
			} else {
				_loudImage.color = _iconColorNonActive;
			}
		}

		private void emmitEffects () {
			// Set All Effects to Off
			{
				Component[] playgrounds = GetComponentsInChildren<ParticlePlayground.PlaygroundParticlesC> ();
				foreach (var playground in playgrounds) {
					playground.gameObject.SetActive (false);
				}
			}
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