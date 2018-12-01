using System;
using Spawners;
using UDBase.Utils;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using Utils;
using ViewModels;
using Zenject;

namespace Controllers {
	[RequireComponent(typeof(AICharacterControl))]
	public class WalkerController : MonoBehaviour {
		abstract class State {
			protected WalkerController Owner;

			protected State(WalkerController owner) {
				Owner = owner;
			}
			
			public virtual void OnEnter() {}
			public virtual void OnExit() {}
			public virtual void Update() {}
		}

		class IdleState : State {
			float _time;
			float _timer;

			public IdleState(WalkerController owner) : base(owner) {}

			public override void OnEnter() {
				_time = 3.0f;
			}
			
			public override void Update() {
				if ( _time > _timer ) {
					Owner.SwitchState(new WalkState(Owner));
				} else {
					_timer += Time.deltaTime;
				}
			}
		}

		class WalkState : State {
			public WalkState(WalkerController owner) : base(owner) {}

			public override void OnEnter() {
				Owner.SelectTarget();
			}

			public override void OnExit() {
				Owner.ClearTarget();
			}

			public override void Update() {
				if ( Owner.IsTargetReached ) {
					Owner.SwitchState(new IdleState(Owner));
				}
			}
		}

		public PrefabSpawner Spawner;
		public float BloodCoeff;
		
		public string StateName;
		
		AICharacterControl _control;
		State _state;
		WaypointSet _waypoints;
		BloodViewModel _blood;
		
		void Awake() {
			_control = GetComponent<AICharacterControl>();
			SwitchState(new IdleState(this));
		}

		[Inject]
		public void Init(WaypointSet waypoints, BloodViewModel blood) {
			_waypoints = waypoints;
			_blood = blood;
		}
		
		void Update() {
			_state.Update();
		}

		void SwitchState(State state) {
			_state?.OnExit();
			_state = state;
			_state.OnEnter();
			StateName = _state.GetType().Name;
		}

		bool IsTargetReached => _control.agent.remainingDistance < _control.agent.stoppingDistance;

		void SelectTarget() {
			Transform randomWaypoint = RandomUtils.GetItem(_waypoints.Waypoints);
			_control.SetTarget(randomWaypoint);
		}

		void ClearTarget() {
			_control.SetTarget(null);
		}

		public void OnKill() {
			var count = 30;
			_blood.Current += count * BloodCoeff;
			Spawner.Spawn(count);
		}
	}
}