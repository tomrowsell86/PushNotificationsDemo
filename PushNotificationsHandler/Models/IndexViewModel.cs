using System.Collections.Generic;
using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.Models
{
    public class IndexViewModel
    {
        public IList<IMessageModel> InboundMessages { get; set; }
        public IList<DeliveryNotificationModel> DeliveryNotifications { get; set; }
    }
}