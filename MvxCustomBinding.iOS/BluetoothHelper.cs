using System;
using System.Threading.Tasks;
using ExternalAccessory;
using Foundation;

namespace MvxCustomBinding.iOS
{
    public class BluetoothHelper : IBluetoothHelper
    {
		public bool IsConnected { get; set; }
		public string DeviceName { get; set; }

		public string EID { get; set; }
		public string ConnectedDevice { get; set; }

		public StreamDelegate _streamDelegate;
		EAAccessory[] _accessoryList;
		EAAccessory _selectedAccessory;
		NSString SessionDataReceivedNotification = (NSString)"SessionDataReceivedNotification";
		string deviceProtocol = "com.app.myprotocol";  // MRI device-specific protocol

		private bool ConnectToDevice(string accessoryId)
		{
			_streamDelegate = StreamDelegate.SharedController();

			_accessoryList = EAAccessoryManager.SharedAccessoryManager.ConnectedAccessories;

			foreach (EAAccessory accessory in _accessoryList)
			{
				var accId = accessory.ValueForKey((NSString)"connectionID");
				var accessoryName = accessory.ValueForKey((NSString)"name");
				var accString = accId.ToString();

				if (DeviceName.Contains(accessoryName.ToString()))
				{
					_selectedAccessory = accessory;
					_streamDelegate.SetupController(accessory, deviceProtocol);
					_streamDelegate.OpenSession();

					Console.WriteLine("Already connected via bluetooth");

					return true;
				}
			}
			return false;
		}

		public async Task<bool> Connect(string name)
		{
			DeviceName = name;
			var isConnected = ConnectToDevice(name);
			return await Task.FromResult(isConnected);
		}
	}
}
