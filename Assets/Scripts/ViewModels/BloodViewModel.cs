using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityWeld.Binding;

namespace ViewModels {
	[Binding]
	public class BloodViewModel : MonoBehaviour, INotifyPropertyChanged {
		[Binding]
		public float Current {
			get { return _current; }
			set {
				var newValue = Mathf.Clamp(value, 0, Max);
				if ( Math.Abs(newValue - _current) > Mathf.Epsilon ) {
					Income += Mathf.Max(newValue - _current, 0);
					_current = newValue;
					OnPropertyChanged();
					OnPropertyChanged(nameof(Normalized));
				}
			}
		}

		[Binding]
		public float Normalized => Current / Max;
		
		public float Income { get; private set; }

		public float Start;
		public float Max;
		
		public event PropertyChangedEventHandler PropertyChanged;

		float _current = 0;

		void Awake() {
			_current = Start;
		}

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}