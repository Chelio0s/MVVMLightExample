
using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MVVMLigtAdvanced.Messages;


namespace MVVMLigtAdvanced.View
{
    /// <summary>
    /// Логика взаимодействия для EmployeesListView.xaml
    /// </summary>
    public partial class EmployeesListView : Window
    {
        public EmployeesListView()
        {
            InitializeComponent();
            Messenger.Default.Register<OpenDialogMessage>(this, OpenDialogMessageHandler);
            Messenger.Default.Register<CloseDialogMessage>(this, CloseDialogMessageHandler);
        }

        private void CloseDialogMessageHandler(CloseDialogMessage obj)
        {
            Close();
        }

        private void OpenDialogMessageHandler(OpenDialogMessage obj)
        {
            switch (obj.WindowName)
            {
                case "CurrentEmployeeView":
                {
                    CurrentEmployeeView cev = new CurrentEmployeeView();
                    cev.Owner = this;
                    cev.ShowDialog();
                    return;
                }
            }
        }
    }
}
