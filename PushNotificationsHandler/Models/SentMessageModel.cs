using System;
using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.Models
{
    public class SentMessageModel
    {
        public Guid MessageId { get; set; }
        public string MessageText { get; set; }
        public DateTime DeliveredAt { get; set; }
        public NotificationSource Source { get; set; }
    }
}