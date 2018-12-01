using Interactors;
using Spawners;
using UnityEngine;
using ViewModels;
using Zenject;

namespace Controllers {
	public class BloodController : MonoBehaviour {
		public GameObject Player;
		public GameStateViewModel GameStateViewModel;
		public float DecreaseValue;

		BloodViewModel _blood;
		
		[Inject]
		public void Init(BloodViewModel blood) {
			_blood = blood;
		}

		void Update() {
			_blood.Current -= DecreaseValue * Time.deltaTime;
			if ( _blood.Current <= 0 ) {
				KillPlayer();
			}
		}

		void KillPlayer() {
			Player.gameObject.SetActive(false);
			Player.GetComponent<PrefabSpawner>().Spawn(50);
			enabled = false;
			var kills = Player.GetComponent<WalkerInteractor>().Count;
			var blood = _blood.Income;
			GameStateViewModel.End(kills, (int)blood);
		}
	}
}