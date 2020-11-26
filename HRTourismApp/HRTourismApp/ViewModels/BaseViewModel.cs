using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HRTourismApp.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private Dictionary<string, object> properties = new Dictionary<string, object>();

		protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
		}

		protected void SetValue<T>(T value, [CallerMemberName] string propertyName = null)
		{
			if (!properties.ContainsKey(propertyName))
			{
				properties.Add(propertyName, default(T));
			}

			var oldValue = GetValue<T>(propertyName);
			if (!EqualityComparer<T>.Default.Equals(oldValue, value))
			{
				properties[propertyName] = value;
				OnPropertyChanged(propertyName);
			}
		}

		protected T GetValue<T>([CallerMemberName] string propertyName = null)
		{
			if (!properties.ContainsKey(propertyName))
			{
				return default(T);
			}
			else
			{
				return (T)properties[propertyName];
			}
		}

		protected bool SetProperty<T>(ref T backingStore, T value,
		   [CallerMemberName] string propertyName = "",
		   Action onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}
	}
}
