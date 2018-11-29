using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MVVMLigtAdvanced.Messages;
using MVVMLigtAdvanced.Models;
using MVVMLigtAdvanced.View;

namespace MVVMLigtAdvanced.ViewModel
{
    public class CurrentEmployeeViewModel : ViewModelBase
    {
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand WindowActivatedCommand { get; set; }

        private IRepository _repository;
        private Employee _employee;
        private string _name;
        private Post _post;

        //поля
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
        public Post Post
        {
            get => _post;
            set
            {
                _post = value;
                RaisePropertyChanged("Post");
            }
        }
        public ObservableCollection<Post> Posts { get; set; }
        public Employee Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                Name = value?.Name;
                Post = value?.Post;
            }
        }

        public CurrentEmployeeViewModel(IRepository repository)
        {
            _repository = repository;
            Posts = new ObservableCollection<Post>(_repository.GetEntityes<Post>());
            WindowActivatedCommand = new RelayCommand(WindowActivatedCommandExecute);
            //commands
            SaveCommand = new RelayCommand(SaveCommandExecute);
            CancelCommand = new RelayCommand(CancelCommandExecute);
            //messenger

        }

        private void CancelCommandExecute()
        {
            Messenger.Default.Send<CloseDialogMessage, CurrentEmployeeView>(new CloseDialogMessage());
        }

        private void SaveCommandExecute()
        {
            if (Employee != null)
            {
                Employee.Name = Name;
                Employee.Post = Post;
                _repository.UpdateEmployee(Employee);
            }
            else
            {
                Employee = new Employee()
                {
                    Post = Post,
                    Name = Name
                };
                _repository.AddEntity(Employee);
            }

            Messenger.Default.Send<CloseDialogMessage, CurrentEmployeeView>(new CloseDialogMessage());
        }


        private void WindowActivatedCommandExecute()
        {
            var parentVM = SimpleIoc.Default.GetInstance<EmployeesViewModel>();
            Employee = parentVM.IsNew ? null : parentVM.CurrentEmployee;
        }
    }
}
