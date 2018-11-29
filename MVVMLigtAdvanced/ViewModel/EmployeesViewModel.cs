using GalaSoft.MvvmLight;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;
using MVVMLigtAdvanced.Models;
using GalaSoft.MvvmLight.Command;
using MVVMLigtAdvanced.Messages;

namespace MVVMLigtAdvanced.ViewModel
{
    public class EmployeesViewModel : ViewModelBase
    {
        //fields
        private ListCollectionView employees;
        private IRepository _repository;
        private bool _isNew;

        //properties
        public Employee CurrentEmployee { get => Employees.CurrentItem as Employee; }
        public bool IsNew { get => _isNew; set => _isNew = value; }
        public ListCollectionView Employees
        {
            get => employees;
            set
            {
                employees = value;
                RaisePropertyChanged("Employees");
            }
        }

        //Комманды
        public RelayCommand ShowEmployeeViewCommand { private set; get; }
        public RelayCommand ShowNewEmployeeCommand { get; set; }


        public EmployeesViewModel(IRepository repository)
        {
            _repository = repository;
            Employees = new ListCollectionView(_repository.GetEntityes<Employee>());

            //инициализация команды
            ShowEmployeeViewCommand = new RelayCommand(ShowEmployeeCommandExecute);
            ShowNewEmployeeCommand = new RelayCommand(ShowNewEmployeeCommandExecute);

            //messenger

        }


        private void ShowNewEmployeeCommandExecute()
        {
            IsNew = true;
            Messenger.Default.Send<OpenDialogMessage>(new OpenDialogMessage("CurrentEmployeeView"));
        }
        private void ShowEmployeeCommandExecute()
        {
            IsNew = false;
            Messenger.Default.Send<OpenDialogMessage>(new OpenDialogMessage("CurrentEmployeeView"));
        }
    }
}

