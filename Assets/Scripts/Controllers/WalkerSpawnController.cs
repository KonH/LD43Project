using UDBase.Utils;
using UnityEngine;
using Utils;
using ViewModels;
using Zenject;

namespace Controllers {
	public class WalkerSpawnController : MonoBehaviour {
		public WalkerController Prefab;
		public float Interval;
		public float IntervalDiff;
		public float MinInterval;
		public int InitialSpawn;

		SpawnPointSet _set;
		WaypointSet _waypoints;
		BloodViewModel _blood;

		float _timer = 0;
		
		[Inject]
		public void Init(SpawnPointSet set, WaypointSet waypoints, BloodViewModel blood) {
			_set = set;
			_waypoints = waypoints;
			_blood = blood;
		}

		void Start() {
			for ( var i = 0; i < InitialSpawn; i++ ) {
				Spawn();
			}
		}

		void Update() {
			if ( _timer > Interval ) {
				Spawn();
				_timer = 0;
				Interval = Mathf.Max(Interval + IntervalDiff * Time.deltaTime, MinInterval);	
			} else {
				_timer += Time.deltaTime;
			}
		}

		void Spawn() {
			var point = RandomUtils.GetItem(_set.Spanwpoints);
			var instance = Instantiate(Prefab, point.position, point.rotation);
			instance.Init(_waypoints, _blood);
		}
	}
}