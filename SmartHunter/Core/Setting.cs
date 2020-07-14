using System.Collections.Generic;
using System.Windows.Controls;

namespace SmartHunter.Core
{
    public class Setting
    {
        public bool Value { get; set; }
        public string Name { get; }
        public string Description { get; }
        public string Checkbox_visibility { get; }
        public string Fontweight { get; }
        public List<Setting>SubSettings { get; }
        public Command TriggerAction { get; }
        public Setting(bool value, string name, string description, Command action = null, string fontweight = "Regular", string checkbox_visibility = "Visible")
        {
            Value = value;
            Name = name;
            Description = description;
            Checkbox_visibility = checkbox_visibility;
            Fontweight = fontweight;
            SubSettings = new List<Setting>();
            TriggerAction = action;            
        }
    }
}
