using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bakery.SXSW
{
	public class SensorConfig : MonoBehaviour {

		#region public properties
		public const int KBN_ATTENTION = 1;
		public const int KBN_CAUTION = 2;
		public const int KBN_WARNING = 3;


		// Uncomfort Index (https://ja.wikipedia.org/wiki/%E4%B8%8D%E5%BF%AB%E6%8C%87%E6%95%B0)
		public const float LIMIT_UNCONFORT_ATTENTION = 80.0f;
		public const float LIMIT_UNCONFORT_CAUTION = 85.0f;
		public const float LIMIT_UNCONFORT_WARNING = 90.0f;

		// HeatStroke Index (from OMRON PDF)
		public const float LIMIT_HEAT_ATTENTION = 25.0f;
		public const float LIMIT_HEAT_CAUTION = 28.0f;
		public const float LIMIT_HEAT_WARNING = 31.0f;

		// Virus (from OMRON PDF)
		public const float LIMIT_VIRUS_TEMP = 22.0f;
		public const float LIMIT_VIRUS_HUM = 20.0f;
		public const int KBN_VIRUS_CAUTION = 1;
		public const int KBN_VIRUS_WARNING = 2;


		// Loud (http://www.toho-seiki.com/info04_e.htm)
		public const float LIMIT_LOUD_ATTENTION = 50.0f;
		public const float LIMIT_LOUD_CAUTION = 70.0f;
		public const float LIMIT_LOUD_WARNING = 90.0f;

		// CSV Constructure
		public const int ROW_NUM_TEMP = 0;
		public const int ROW_NUM_HUM = 1;
		public const int ROW_NUM_LX = 2;
		public const int ROW_NUM_UV = 3;
		public const int ROW_NUM_DB = 4;
		public const int ROW_NUM_UNCOMFORT = 5;
		public const int ROW_NUM_HEATSTROKE = 6;

		// Effect Name
		public const string EFFECT_NAME_UNCOMFORT = "uncomfortEffect";
		public const string EFFECT_NAME_HEAT = "heatEffect";
		public const string EFFECT_NAME_VIRUS = "virusEffect";
		public const string EFFECT_NAME_LOUD = "loudEffect";

		// Category Text
		public const string TXT_CATEGORY_INFORMATION = "INFORMATION";
		public const string TXT_CATEGORY_ATTENTION = "ATTENTION!";
		public const string TXT_CATEGORY_CAUTION = "CAUTION!!";
		public const string TXT_CATEGORY_WARNING = "WARNING!!!";

		#endregion

		#region MonoBehaviour functions

		#endregion
	}
}