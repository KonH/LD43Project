using Triggers;
using UnityEngine;

namespace Interactors {
	[RequireComponent(typeof(Rigidbody))]
	public class BaseInteractor<T>: MonoBehaviour where T : BaseTrigger {
		public int Count { get; private set; }
		
		void OnCollisionEnter(Collision other) {
			var trigger = other.gameObject.GetComponent<T>();
			if ( trigger && trigger.enabled ) {
				trigger.Kill();
				Count++;
			}
		}
	}
}