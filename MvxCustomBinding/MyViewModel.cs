using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Windows.Input;

namespace MvxCustomBinding
{
    public class MyViewModel : MvxViewModel
    {
        private readonly INotificationService _notificationService;

        public MyViewModel(INotificationService notificationService)
        {
            _notificationService = notificationService;
            MyCommand = new MvxCommand(MyCommandExecute);
        }

        public bool MyBoolProperty
        {
            get => _myBoolProperty;
            set { _myBoolProperty = value; RaisePropertyChanged(); }
        }

        private bool _myBoolProperty;

        public ICommand MyCommand { get; }

        private void MyCommandExecute()
        {
            MyBoolProperty = !MyBoolProperty;
            if (MyBoolProperty)
                _notificationService.Notify();
        }
    }
}
