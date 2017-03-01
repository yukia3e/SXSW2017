using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Bakery.SXSW
{
	public interface FPSCanvasUpdaterReceiver : IEventSystemHandler {
		void OnRecieve();
	}
}
