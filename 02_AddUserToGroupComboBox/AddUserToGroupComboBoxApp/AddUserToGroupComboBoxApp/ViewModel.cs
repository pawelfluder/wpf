using DelegateCommand = Microsoft.Practices.Prism.Commands.DelegateCommand;

namespace CheckBoxComboBoxApp
{
    public class ViewModel
    {
        public ViewModel()
        {
            AddUsersToGroupCommand = new DelegateCommand(AddUsersToGroup);
        }

        private void AddUsersToGroup()
        {
        }

        public DelegateCommand AddUsersToGroupCommand
        {
            get;
            set;
        }
    }
}
