using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Diagnostics;
using System.Windows.Input;

namespace MvxCustomBinding
{
    public class MyViewModel : MvxViewModel
    {
        private readonly INotificationService _notificationService;
        private readonly IBluetoothHelper _bluetoothHelper;

        public MyViewModel(INotificationService notificationService, IBluetoothHelper bluetoothHelper)
        {
            _notificationService = notificationService;
            _bluetoothHelper = bluetoothHelper;
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

            var deviceName = "MyDeviceName";
            if (!_bluetoothHelper.IsConnected)
                _bluetoothHelper.Connect(deviceName);

            Debug.Write(string.Format("Bluetooth is {0} connected to {1}", _bluetoothHelper.IsConnected ? string.Empty : "not", deviceName));
        }
    }
}
