using System.Collections.Generic;
using System.Windows.Input;
using CheckBoxComboBoxApp.PiriosUserControl;

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

        public ICommand addContactsToGroupCommand;

        public ICommand AddContactsToGroupCommand
        {
            get
            {
                if (addContactsToGroupCommand == null)
                    addContactsToGroupCommand = new RelayCommand<object>(o => CheckBox_Click(o));
                return addContactsToGroupCommand;
            }
        }

        void CheckBox_Click(object obj)
        {
        }
    }
}
