using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Bakery.SXSW
{
	public interface EmissionControllerReceiver : IEventSystemHandler {
		void OnRecieve();
	}
}
