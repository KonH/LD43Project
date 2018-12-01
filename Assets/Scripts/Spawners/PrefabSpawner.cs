using UnityEngine;

namespace Spawners {
	public class PrefabSpawner : MonoBehaviour {
		public GameObject Prefab;
		
		public void Spawn(int count) {
			for ( var i = 0; i < count; i++ ) {
				Instantiate(Prefab, transform.position, transform.rotation);
			}
		}
	}
}