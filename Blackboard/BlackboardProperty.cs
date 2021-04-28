using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackboardN
{
    /// <summary>
    /// Strongly typed property identifier for properties on a blackboard
    /// </summary>
    /// <typeparam name="T">The type of the property value it identifies</typeparam>
    public class BlackboardProperty<T> : IBlackboardProperty
    {
        public string Source { get; set; }
        public string Name { get; set; }
        public string Key { get { return $"{Source}.{Name}"; } }
        
        public T Value 
        { 
            get { return (T)ValueObject; } 
            set { ValueObject = value; } 
        }

        public object ValueObject { get; set; }

        public BlackboardProperty(string source,string name)
        {
            Source = source;
            Name = name;
            Value = default(T);
        }

        public BlackboardProperty(string source, string name, T value)
        {
            Source = source;
            Name = name;
            Value = value;
        }
    }

    public interface IBlackboardProperty
    {
        string Source { get; set; }
        string Name { get; set; }
        string Key { get;  }
        object ValueObject { get; set; }
    }
}
