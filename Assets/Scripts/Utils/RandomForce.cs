using UnityEngine;

namespace Utils {
	[RequireComponent(typeof(Rigidbody))]
	public class RandomForce : MonoBehaviour {
		public float MinForce;
		public float MaxForce;
		
		void Start() {
			GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * Random.Range(MinForce, MaxForce));
		}
	}
}