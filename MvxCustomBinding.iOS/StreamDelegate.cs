using System;
using System.Diagnostics;
using ExternalAccessory;
using Foundation;

namespace MvxCustomBinding.iOS
{
    public class StreamDelegate : NSStreamDelegate
    {
        NSString SessionDataReceivedNotification = (NSString)"SessionDataReceivedNotification";

        public static EAAccessory _accessory;
        public static string _protocolString;

        EASession _session;
        NSMutableData _readData;

        public static StreamDelegate SharedController()
        {
            StreamDelegate streamDelegate = null;

            if (streamDelegate == null)
            {
                streamDelegate = new StreamDelegate();
            }

            return streamDelegate;

        }

        public void SetupController(EAAccessory accessory, string protocolString)
        {

            _accessory = accessory;
            _protocolString = protocolString;

        }

        public bool OpenSession()
        {

            Console.WriteLine("opening new session");

            _accessory.WeakDelegate = this;

            if (_session == null)
                _session = new EASession(_accessory, _protocolString);

            // Open both input and output streams even if the device only makes use of one of them

            _session.InputStream.Delegate = this;
            _session.InputStream.Schedule(NSRunLoop.Current, NSRunLoopMode.Default);
            _session.InputStream.Open();

            _session.OutputStream.Delegate = this;
            _session.OutputStream.Schedule(NSRunLoop.Current, NSRunLoopMode.Default);
            _session.OutputStream.Open();

            return (_session != null);

        }

        public void CloseSession()
        {
            _session.InputStream.Unschedule(NSRunLoop.Current, NSRunLoopMode.Default);
            _session.InputStream.Delegate = null;
            _session.InputStream.Close();

            _session.OutputStream.Unschedule(NSRunLoop.Current, NSRunLoopMode.Default);
            _session.OutputStream.Delegate = null;
            _session.OutputStream.Close();

            _session = null;

        }


        public nuint ReadBytesAvailable()
        {
            return _readData.Length;
        }


        public NSData ReadData(nuint bytesToRead)
        {

            NSData data = null;

            if (_readData.Length >= bytesToRead)
            {
                NSRange range = new NSRange(0, (nint)bytesToRead);
                data = _readData.Subdata(range);
                _readData.ReplaceBytes(range, IntPtr.Zero, 0);
            }

            Debug.WriteLine("Data read: " + data);
            return data;

        }

        void ReadData()
        {
            nuint bufferSize = 128;
            byte[] buffer = new byte[bufferSize];

            while (_session.InputStream.HasBytesAvailable())
            {
                nint bytesRead = _session.InputStream.Read(buffer, bufferSize);

                if (_readData == null)
                {
                    _readData = new NSMutableData();
                }
                _readData.AppendBytes(buffer, 0, bytesRead);
                Console.WriteLine(buffer);
            }

            NSNotificationCenter.DefaultCenter.PostNotificationName(SessionDataReceivedNotification, this);
        }

        public override void HandleEvent(NSStream theStream, NSStreamEvent streamEvent)
        {

            switch (streamEvent)
            {

                case NSStreamEvent.None:
                    Console.WriteLine("StreamEventNone");
                    break;
                case NSStreamEvent.HasBytesAvailable:
                    Console.WriteLine("StreamEventHasBytesAvailable");
                    ReadData();
                    break;
                case NSStreamEvent.HasSpaceAvailable:
                    Console.WriteLine("StreamEventHasSpaceAvailable");
                    // Do write operations to the device here
                    break;
                case NSStreamEvent.OpenCompleted:
                    Console.WriteLine("StreamEventOpenCompleted");
                    break;
                case NSStreamEvent.ErrorOccurred:
                    Console.WriteLine("StreamEventErroOccurred");
                    break;
                case NSStreamEvent.EndEncountered:
                    Console.WriteLine("StreamEventEndEncountered");
                    break;
                default:
                    Console.WriteLine("Stream present but no event");
                    break;
            }
        }

    }
}
