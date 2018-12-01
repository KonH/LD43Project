using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityWeld.Binding;

namespace ViewModels {
	[Binding]
	public class GameStateViewModel : MonoBehaviour, INotifyPropertyChanged {
		[Binding] public bool Ended   { get; private set; }
		[Binding] public int  Kills   { get; private set; }
		[Binding] public int  Blood   { get; private set; }
		[Binding] public int  Elapsed { get; private set; }
		
		public event PropertyChangedEventHandler PropertyChanged;

		public void End(int kills, int blood) {
			Ended = true;
			Kills = kills;
			Blood = blood;
			Elapsed = (int)Time.timeSinceLevelLoad;
			OnPropertyChanged(nameof(Ended));
			OnPropertyChanged(nameof(Kills));
			OnPropertyChanged(nameof(Blood));
			OnPropertyChanged(nameof(Elapsed));
		}
		
		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}