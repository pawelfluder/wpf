using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Pirios.DDesk.Libs.Common.Helpers;

namespace Collection.CustomControls
{
    public partial class AddUserToGroupsComboBox : INotifyPropertyChanged
    {
        public static readonly DependencyProperty GroupOfUsersSourceProperty =
            DependencyProperty.Register("GroupOfUsersSource", typeof(SelectionList<string>),
                                        typeof(AddUserToGroupsComboBox),
                                        new PropertyMetadata(null, OnGroupOfUsersSourceChanged));

        private static void OnGroupOfUsersSourceChanged(DependencyObject a_d, DependencyPropertyChangedEventArgs a_args)
        {
            ((AddUserToGroupsComboBox)a_d).RaisePropertyChanged("GroupOfUsersSource");
        }

        public SelectionList<string> GroupOfUsersSource
        {
            get { return (SelectionList<string>)GetValue(GroupOfUsersSourceProperty); }
            set { SetValue(GroupOfUsersSourceProperty, value); }
        }

        public static readonly DependencyProperty SaveCommandProperty =
            DependencyProperty.Register("SaveCommand", typeof(ICommand),
            typeof(AddUserToGroupsComboBox), new PropertyMetadata(null, OnSaveCommandChanged));

        private static void OnSaveCommandChanged(DependencyObject a_d, DependencyPropertyChangedEventArgs a_args)
        {
            ((AddUserToGroupsComboBox)a_d).RaisePropertyChanged("SaveCommand");
        }

        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(SaveCommandProperty); }
            set { SetValue(SaveCommandProperty, value); }
        }

        public AddUserToGroupsComboBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string a_propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(a_propertyName));
            }
        }

        private void AddToGroupComboBoxDropDownOpened(object a_sender, EventArgs a_args)
        {
            UnselectAllGroups();
        }

        private void UnselectAllGroups()
        {
            if (GroupOfUsersSource != null)
            {
                GroupOfUsersSource.UnselectAll();
            }
        }
    }
}
