using UnityEngine;

namespace Utils {
	public class SpawnPointSet : MonoBehaviour {
		[HideInInspector]
		public Transform[] Spanwpoints;
		
		void Awake() {
			Spanwpoints = new Transform[transform.childCount];
			for ( var i = 0; i < transform.childCount; i++ ) {
				Spanwpoints[i] = transform.GetChild(i);
			}
		}
	}
}