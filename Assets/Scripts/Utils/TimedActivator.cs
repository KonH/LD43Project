using System.Collections;
using UnityEngine;

namespace Utils {
	public class TimedActivator : MonoBehaviour {
		public MonoBehaviour Comp;
		public float Time;

		void Awake() {
			Comp.enabled = false;
		}

		IEnumerator Start() {
			yield return new WaitForSeconds(Time);
			Comp.enabled = true;
		}
		
	}
}