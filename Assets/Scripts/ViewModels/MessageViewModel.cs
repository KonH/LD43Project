using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DG.Tweening;
using JetBrains.Annotations;
using UDBase.Utils;
using UnityEngine;
using UnityWeld.Binding;
using Random = UnityEngine.Random;

namespace ViewModels {
	[Binding]
	public class MessageViewModel : MonoBehaviour, INotifyPropertyChanged {
		[Binding]
		public string Message {
			get { return _message; }
			set {
				if ( value != _message ) {
					_message = value;
					OnPropertyChanged();
				}
			}
		}

		public RectTransform TextTransform;
		
		public string FirstMessage;
		public string[] Messages;
		
		public event PropertyChangedEventHandler PropertyChanged;

		string _message;
		Vector2 _scale;
		bool _firstTaken;
		
		void Start() {
			TextTransform.localScale = Vector3.zero;
			StartCoroutine(UpdateRoutine());
		}

		IEnumerator UpdateRoutine() {
			while ( true ) {
				Message = GetMessage();
				TextTransform.DOScale(Vector3.one, 0.33f).SetEase(Ease.InOutSine);
				yield return new WaitForSeconds(Random.Range(2, 3));
				TextTransform.DOScale(Vector3.zero, 0.22f).SetEase(Ease.InOutSine);
				yield return new WaitForSeconds(1);
				Message = string.Empty;
				yield return new WaitForSeconds(Random.Range(2, 4));
			}
		}

		string GetMessage() {
			if ( !_firstTaken ) {
				_firstTaken = true;
				return FirstMessage;
			}
			return RandomUtils.GetItem(Messages);
		}

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}