using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVMLigtAdvanced.Messages;
using MVVMLigtAdvanced.View;

namespace MVVMLigtAdvanced.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand openEmployeesViewCommand;
        private RelayCommand openPostsViewCommand;
        public RelayCommand OpenEmployeesViewCommand { get => openEmployeesViewCommand; set => openEmployeesViewCommand = value; }
        public RelayCommand OpenPostsViewCommand { get => openPostsViewCommand; set => openPostsViewCommand = value; }

        public MainViewModel()
        {
            //commands init
           OpenEmployeesViewCommand = new RelayCommand(OpenEmployeesCommandExecute);
           OpenPostsViewCommand = new RelayCommand(OpenPostsViewCommandExecute);
        }

    

        private void OpenPostsViewCommandExecute()
        {
            Messenger.Default.Send<OpenDialogMessage, MainWindow>(new OpenDialogMessage("PostsView"));
        }

        private void OpenEmployeesCommandExecute()
        {
            Messenger.Default.Send<OpenDialogMessage, MainWindow>(new OpenDialogMessage("EmployeesListView"));
        }
    }
}