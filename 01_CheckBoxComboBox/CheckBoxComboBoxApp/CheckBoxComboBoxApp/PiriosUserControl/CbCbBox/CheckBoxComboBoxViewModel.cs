using System.Windows.Input;

namespace CheckBoxComboBoxApp.PiriosUserControl.CbCbBox
{
    class CheckBoxComboBoxViewModel
    {
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

        private void SetBtnClickCmd()
        {
            btnClickCmd = new RelayCommand<object>(o => CheckBox_Click(o));
        }

        private void CheckBox_Click(object obj)
        {
        }
    }
}
