
using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MVVMLigtAdvanced.Messages;


namespace MVVMLigtAdvanced.View
{
    /// <summary>
    /// Логика взаимодействия для CurrentEmployeeView.xaml
    /// </summary>
    public partial class CurrentEmployeeView : Window
    {
        public CurrentEmployeeView()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseDialogMessage>(this, CloseMessageHandler);
        }

        private void CloseMessageHandler(CloseDialogMessage obj)
        {
            this.Close();
        }
    }
}
