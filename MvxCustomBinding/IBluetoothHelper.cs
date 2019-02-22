using System.Threading.Tasks;

namespace MvxCustomBinding
{
    public interface IBluetoothHelper
    {
        bool IsConnected { get; set; }

        string DeviceName { get; set; }

        Task<bool> Connect(string deviceName);
    }
}
