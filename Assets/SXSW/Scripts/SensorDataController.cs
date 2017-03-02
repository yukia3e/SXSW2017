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
		GameObject _fpsCanvasUpdater;
		#endregion



		#region private properties
		private TextAsset _csvFile;
		private List<string[]> _csvDatas = new List<string[]>();
		private int _lineCount = 0;
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

			// for SXSW
			readFile (Random.Range( 0, 10 ).ToString());

			int sensorNo = 0;
			foreach (GameObject sensor in _sensors) {
				sensor.GetComponent<SensorController> ().updateSensor (_csvDatas [sensorNo]);
				sensorNo += 1;
			};

			drawSensorData ();

		}

		private void bangUpdateAnimation(){
			BangInput bang = _sensorUpdate.GetComponent<BangInput> ();
			bang.Bang ();
		}

		private void readFile(string footer = null){
			
			string csvFileName = "sensorData_" + footer;
			Debug.Log (csvFileName);

			_csvFile = new TextAsset();
			_csvFile = Resources.Load("CSV/" + csvFileName) as TextAsset;
			StringReader reader = new StringReader(_csvFile.text);

			_csvDatas = new List<string[]>();
			while(reader.Peek() > -1) {
				string line = reader.ReadLine();
				_csvDatas.Add(line.Split(','));
				_lineCount++;
			}
		}

		private void drawSensorData () {

			string time = System.DateTime.Now.ToString("HH:mm");
			if (System.DateTime.Now.Second < 30) {
				time += ":00";
			} else {
				time += ":30";
			}

			List<string> sensorData = new List<string>();
			sensorData.Add("Update sensor data (" + time + ") - start.\n");

			int sensorNo = 0;

			foreach (GameObject sensor in _sensors) {
				sensorData.Add ("{\n");
				sensorData.Add ("    \"SensorNo\": \"" + (sensorNo + 1) + "\"\n");
				sensorData.Add ("    \"Values\": [\n");
				sensorData.Add ("      {\n");
				sensorData.Add ("        \"Temp\": \"" + _csvDatas [sensorNo] [SensorConfig.ROW_NUM_TEMP] + "\"\n");
				sensorData.Add ("        \"Humidity\": \"" + _csvDatas [sensorNo] [SensorConfig.ROW_NUM_HUM] + "\"\n");
				sensorData.Add ("        \"lx\": \"" + _csvDatas [sensorNo] [SensorConfig.ROW_NUM_LX] + "\"\n");
				sensorData.Add ("        \"UV\": \"" + _csvDatas [sensorNo] [SensorConfig.ROW_NUM_UV] + "\"\n");
				sensorData.Add ("        \"dB\": \"" + _csvDatas [sensorNo] [SensorConfig.ROW_NUM_DB] + "\"\n");
				sensorData.Add ("        \"Uncomfort Index\": \"" + _csvDatas [sensorNo] [SensorConfig.ROW_NUM_UNCOMFORT] + "\"\n");
				sensorData.Add ("        \"HeatStroke Index\": \"" + _csvDatas [sensorNo] [SensorConfig.ROW_NUM_HEATSTROKE] + "\"\n");
				sensorData.Add ("      }\n");
				sensorData.Add ("    ]\n");
				sensorData.Add ("}\n");

				sensorNo++;
			}

			sensorData.Add ("Update sensor data (" + time + ") - end.\n");

			_fpsCanvasUpdater.GetComponent<FPSCanvasUpdater> ().lines = sensorData;

			ExecuteEvents.Execute<FPSCanvasUpdaterReceiver>(
				target: _fpsCanvasUpdater, 
				eventData: null, 
				functor: (reciever, eventData) => reciever.OnRecieve()
			); 
		}
		#endregion
	}
}