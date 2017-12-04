using System.Collections.Generic;

namespace CheckBoxComboBoxApp
{
    public class ViewModel
    {
        public Dictionary<string, object> Items { get; set; }

        public ViewModel()
        {
            Items = new Dictionary<string, object>();
            Items.Add("Chennai", "MAS");
            Items.Add("Trichy", "TPJ");
            Items.Add("Bangalore", "SBC");
            Items.Add("Coimbatore", "CBE");
        }
    }
}
