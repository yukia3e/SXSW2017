using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using System.IO;
using Klak.Wiring;
using UnityEngine.UI;

namespace Bakery.SXSW
{
	public class SensorDataController : MonoBehaviour {

		#region Editable properties
		[SerializeField]
		GameObject[] _sensors;

		[SerializeField]
		GameObject _sensorUpdate;

		[SerializeField]
		Text _infoCanvas;

		[SerializeField]
		ScrollRect _scrollRect;
		#endregion



		#region private properties
		private string header;
		private string time;
		private TextAsset csvFile;
		private List<string[]> csvDatas = new List<string[]>();
		private int lineCount = 0;
		#endregion

		#region MonoBehaviour functions
		void Start () {
			StartCoroutine(loop());
		}
		
		private IEnumerator loop() {
			while (true) {
				onTimer();
				yield return new WaitForSeconds(30.0f);
			}
		}

		private void onTimer() {
			bangUpdateAnimation ();

			time = null;
			// for SXSW
			time = System.DateTime.Now.ToString("HHmm");
			if (System.DateTime.Now.Second < 30) {
				time += "00";
			} else {
				time += "30";
			}

			_infoCanvas.text = time + " update start.\n";

			_scrollRect.verticalNormalizedPosition = 0f;

			ReadFile (time);

			int sensorNo = 0;
			foreach (GameObject sensor in _sensors) {
				sensor.GetComponent<SensorController> ().updateSensor (csvDatas [sensorNo]);
				drawSensorData (sensorNo + 1, csvDatas [sensorNo]);
				sensorNo++;
			}

			_infoCanvas.text += time + " update end.\n";

			_scrollRect.verticalNormalizedPosition = 0f;

		}

		private void bangUpdateAnimation(){
			BangInput bang = _sensorUpdate.GetComponent<BangInput> ();
			bang.Bang ();
		}

		private void ReadFile(string time = null){
			csvFile = new TextAsset();
			csvDatas = new List<string[]>();

			header = "sensorData_";

			// for Test
			if (System.DateTime.Now.Second < 30) {
				time = "test1";
			} else {
				time = "test2";
			}


			csvFile = Resources.Load("CSV/" + header + time) as TextAsset;
			StringReader reader = new StringReader(csvFile.text);

			while(reader.Peek() > -1) {
				string line = reader.ReadLine();
				csvDatas.Add(line.Split(','));
				lineCount++;
			}
		}

		private void drawSensorData (int sensorNo, string[] datas) {
			string sensorData = "{\n" +
				"    \"SensorNo\": \"" + sensorNo + "\"\n" +
				"    \"Values\": [\n" +
				"      {\n" +
				"        \"Temp\": \"" + datas [SensorConfig.ROW_NUM_TEMP] + "\"\n" +
				"        \"Humidity\": \"" + datas [SensorConfig.ROW_NUM_HUM] + "\"\n" +
				"        \"lx\": \"" + datas [SensorConfig.ROW_NUM_LX] + "\"\n" +
				"        \"UV\": \"" + datas [SensorConfig.ROW_NUM_UV] + "\"\n" +
				"        \"dB\": \"" + datas [SensorConfig.ROW_NUM_DB] + "\"\n" +
				"        \"Confort Index\": \"" + datas [SensorConfig.ROW_NUM_UNCOMFORT] + "\"\n" +
				"        \"HeatStroke Index\": \"" + datas [SensorConfig.ROW_NUM_HEATSTROKE] + "\"\n" +
				"      }\n" +
				"    ]\n" +
				"}\n";
			_infoCanvas.text += sensorData;

			_scrollRect.verticalNormalizedPosition = 0f;
		}
		#endregion
	}
}