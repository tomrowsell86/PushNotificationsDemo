using System.Collections.Generic;
using PushNotificationsHandler.Models;

namespace PushNotificationsHandler.Repositories.Interface
{
    public interface IDeliveryNotificationRepository
    {
        void Save(SentMessageModel sentMessage);
        IList<SentMessageModel> GetAllDeliveredMessages();
    }
}