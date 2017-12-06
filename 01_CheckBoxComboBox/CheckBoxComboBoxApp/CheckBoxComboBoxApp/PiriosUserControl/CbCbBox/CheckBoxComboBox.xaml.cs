using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CheckBoxComboBoxApp.PiriosUserControl.CbCbBox
{
    public partial class CheckBoxComboBox : UserControl
    {
        private const string ALL_ITEM_DESCRIPTION = "All";

        private ObservableCollection<PopupListOneLine> popupList;

        public CheckBoxComboBox()
        {
            InitializeComponent();
            popupList = new ObservableCollection<PopupListOneLine>();
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(Dictionary<string, object>), typeof(CheckBoxComboBox), 
                new FrameworkPropertyMetadata(null, OnItemsSourceChanged));

        public Dictionary<string, object> ItemsSource
        {
            get
            {
                return (Dictionary<string, object>)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CheckBoxComboBox control = (CheckBoxComboBox)d;
            control.InitializePopupList();
        }

        public static readonly DependencyProperty SaveCommandProperty = DependencyProperty.Register("SaveCommand", typeof(ICommand),
            typeof(CheckBoxComboBox), new PropertyMetadata(null, OnSaveCommandChanged));

        private static void OnSaveCommandChanged(DependencyObject a_d, DependencyPropertyChangedEventArgs a_args)
        {
            ((CheckBoxComboBox)a_d).RaisePropertyChanged("SaveCommand");
        }

        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(SaveCommandProperty); }
            set { SetValue(SaveCommandProperty, value); }
        }

        private void InitializePopupList()
        {
            popupList.Clear();
            if (this.ItemsSource.Count > 0)
                popupList.Add(new PopupListOneLine("All"));
            foreach (KeyValuePair<string, object> keyValue in ItemsSource)
            {
                PopupListOneLine oneLine = new PopupListOneLine(keyValue.Key);
                popupList.Add(oneLine);
            }
            MainComboBox.ItemsSource = popupList;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox clickedBox = (CheckBox)sender;

            
            if ((string)clickedBox.Content == ALL_ITEM_DESCRIPTION)
            {
                if (clickedBox.IsChecked == true)
                {
                    foreach (PopupListOneLine node in popupList)
                    {
                        node.IsSelected = true;
                    }
                }
                else
                {
                    foreach (PopupListOneLine node in popupList)
                    {
                        node.IsSelected = false;
                    }
                }                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string a_propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(a_propertyName));
            }
        }
    }
}