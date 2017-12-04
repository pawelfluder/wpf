using System.Collections.Generic;
using System.Windows;

namespace CheckBoxComboBoxApp.PiriosUserControl.CbCbBox
{
    public partial class CheckBoxComboBox
    {
        public CheckBoxComboBox()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(Dictionary<string, object>), typeof(CheckBoxComboBox), new FrameworkPropertyMetadata(null, OnItemsSourceChanged));

        public Dictionary<string, object> ItemsSource
        {
            get { return (Dictionary<string, object>)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CheckBoxComboBox control = (CheckBoxComboBox)d;
            control.InitializePopupListLines();
        }

        private void InitializePopupListLines()
        {
            List<PopupListOneLine> popupList = new List<PopupListOneLine>();

            foreach (KeyValuePair<string, object> keyValue in ItemsSource)
            {
                PopupListOneLine oneLine = new PopupListOneLine(keyValue.Key);
                popupList.Add(oneLine);
            }
            MainComboBox.ItemsSource = popupList;
        }
    }
}