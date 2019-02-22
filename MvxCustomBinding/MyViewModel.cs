using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Windows.Input;

namespace MvxCustomBinding
{
    public class MyViewModel : MvxViewModel
    {
        public MyViewModel()
        {
            MyCommand = new MvxCommand(MyCommandExecute);
        }

        public bool MyBoolProperty
        {
            get => _myBoolProperty;
            set { _myBoolProperty = value; RaisePropertyChanged(); }
        }

        private bool _myBoolProperty;

        public ICommand MyCommand { get; }

        private void MyCommandExecute() => MyBoolProperty = !MyBoolProperty;
    }
}
