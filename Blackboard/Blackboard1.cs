using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackboardN
{
    public class Blackboard1 : INotifyPropertyChanged
    {
        Dictionary<string, object> _dict = new Dictionary<string, object>();

        public bool ContainsKey<T>(BlackboardProperty<T> property)
        {
            return _dict.ContainsKey(property.Key);
        }

        public T Get<T>(BlackboardProperty<T> property)
        {
            return (T)_dict[property.Key];
        }

        public T Get<T>(string Key)
        {
            return (T)_dict[Key];
        }

        public object Get(string Key)
        {
            return _dict[Key];
        }

        public void Set<T>(BlackboardProperty<T> property, T value)
        {
            _dict[property.Key] = value;
            OnPropertyChanged(property.Key);
        }

        public int Count { get => _dict.Count; }

        #region property change notification
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
