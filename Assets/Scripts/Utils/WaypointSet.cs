using UnityEngine;

namespace Utils {
	public class WaypointSet : MonoBehaviour {
		[HideInInspector]
		public Transform[] Waypoints;
		
		void Awake() {
			Waypoints = new Transform[transform.childCount];
			for ( var i = 0; i < transform.childCount; i++ ) {
				Waypoints[i] = transform.GetChild(i);
			}
		}
	}
}