using System.Windows.Input;

namespace CheckBoxComboBoxApp.PiriosUserControl.CbCbBox
{
    public class CheckBoxComboBoxViewModel
    {
        public CheckBoxComboBoxViewModel()
        {
            
        }

        public ICommand btnClickCmd;

        public ICommand BtnClickCmd
        {
            get
            {
                if (btnClickCmd == null)
                    btnClickCmd = new RelayCommand<object>(o => CheckBox_Click(o));
                return btnClickCmd;
            }
        }

        private void CheckBox_Click(object sender)
        {
           
        }
    }
}
