using System;
using System.Collections.Generic;
using System.Linq;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Repositories.Interface;

namespace PushNotificationsHandler.Repositories
{
    public class InMemoryDeliveryNotificationRepository : IDeliveryNotificationRepository
    {
        private readonly Dictionary<Guid, SentMessageModel> _cache = new Dictionary<Guid, SentMessageModel>();
        private object syncObj = new object();

        public void Save(SentMessageModel sentMessage)
        {
            lock (syncObj)
            {
                _cache.Add(sentMessage.MessageId, sentMessage);
            }
        }

        public IList<SentMessageModel> GetAllDeliveredMessages()
        {
            return _cache.Values.ToList();
        }
    }
}