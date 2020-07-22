using System.Collections.Generic;
using System.ComponentModel;

namespace SmartHunter.Core
{
    public class Setting : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private bool _value;
        private bool _enabled;
        
        public bool Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value == value)
                    return;
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                if (_enabled == value)
                    return;
                _enabled = value;
                OnPropertyChanged(nameof(Enabled));
            }
        }

       
        public string Name { get; }
        public string Label { get; }
        public string Description { get; }        
        public string Fontweight { get; }
        public List<Setting>SubSettings { get; }
        public Command TriggerAction { get; }
        public Setting(bool _value, bool _enabled, string name, string label, string description, Command action = null)
        {
            Value = _value;
            Enabled = _enabled;
            Name = name;
            Label = label;
            Description = description;                       
            SubSettings = new List<Setting>(); 
            TriggerAction = action;            
        }                
    }
}
