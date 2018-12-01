using UnityEngine;
using UnityEngine.Events;

namespace Triggers {
	public abstract class BaseTrigger : MonoBehaviour {
		public UnityEvent OnKill;
		
		public virtual void Kill() {
			gameObject.SetActive(false);
			OnKill.Invoke();
		}
	}
}