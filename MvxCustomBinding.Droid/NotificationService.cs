using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;

namespace MvxCustomBinding.Android
{
    public class NotificationService : INotificationService
    {
        static readonly int NOTIFICATION_ID = 1000;
        static readonly string CHANNEL_ID = "local_notification";
        private Context _context;

        public NotificationService(Context context)
        {
            _context = context;
        }

        public void Notify()
        {
            CreateNotificationChannel();
            SendNotification();
        }

        private void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var name = "MvxCustomBinding.Android";
            var description = "channel description";
            var channel = new NotificationChannel(CHANNEL_ID, name, NotificationImportance.Default)
            {
                Description = description
            };

            var notificationManager = (NotificationManager)_context.GetSystemService(Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        private void SendNotification()
        {
            var builder = new NotificationCompat.Builder(_context, CHANNEL_ID)
              .SetAutoCancel(true) // Dismiss the notification from the notification area when the user clicks on it
              .SetContentTitle("Button Clicked") // Set the title
              .SetSmallIcon(Droid.Resource.Drawable.ic_icon_warning) // This is the icon to display
              .SetContentText("Notification content")
              .SetChannelId(CHANNEL_ID);

            var notificationManager = NotificationManagerCompat.From(_context);
            notificationManager.Notify(NOTIFICATION_ID, builder.Build());
        }
    }
}