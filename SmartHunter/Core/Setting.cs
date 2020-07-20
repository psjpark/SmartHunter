using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;

namespace SmartHunter.Core
{
    public class Setting : INotifyPropertyChanged
    {
        //public bool Value { get; set; }
        //public bool Enabled { get; set; }

        private bool _value;
        private bool _enabled;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public bool Value
        {
            get => _value;
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
            get => _enabled;
            set
            {
                if (_enabled == value) return;
                _enabled = value;
                OnPropertyChanged(nameof(Enabled));
            }
        }

        public string Name { get; }
        public string Label { get; }
        public string Description { get; }
        public string Checkbox_visibility { get; }
        public string Fontweight { get; }
        public List<Setting>SubSettings { get; }
        public Command TriggerAction { get; }
        public Setting(bool value, bool enabled, string name, string label, string description, Command action = null)
        {
            Value = value;
            Enabled = enabled;
            Name = name;
            Label = label;
            Description = description;                       
            SubSettings = new List<Setting>(); 
            TriggerAction = action;            
        }
    }
}
