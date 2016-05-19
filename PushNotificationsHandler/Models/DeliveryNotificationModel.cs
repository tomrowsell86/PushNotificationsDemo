using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.Models
{
    public class DeliveryNotificationModel
    {
        public NotificationSource Source { get; set; }
        public string Description { get; set; }
    }
}