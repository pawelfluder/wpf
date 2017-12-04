using System.ComponentModel;

namespace CheckBoxComboBoxApp.PiriosUserControl.CbCbBox
{
    public class PopupListOneLine : INotifyPropertyChanged
    {
        private string lineTitle;
        private bool isSelected;

        public PopupListOneLine(string lineTitle)
        {
            LineTitle = lineTitle;
        }

        public string LineTitle
        {
            get
            {
                return lineTitle;
            }
            set
            {
                lineTitle = value;
                NotifyPropertyChanged("LineTitle");
            }
        }
        
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                NotifyPropertyChanged("IsSelected");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
