using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MVVMLigtAdvanced.Messages;
using MVVMLigtAdvanced.View;

namespace MVVMLigtAdvanced
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<OpenDialogMessage>(this, OpenDialogMessageHandler);
        }
        private void OpenDialogMessageHandler(OpenDialogMessage obj)
        {
            switch (obj.WindowName)
            {
                case "EmployeesListView":
                    {
                        EmployeesListView view = new EmployeesListView();
                        view.ShowDialog();
                    }
                    return;
                case "PostsView":
                    {
                        PostsView view = new PostsView();
                        view.ShowDialog();
                    }
                    return;
            }
        }
    }
}
