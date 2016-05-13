using System;
using System.Collections.Generic;
using PushNotificationsHandler.Models.Services;
using PushNotificationsHandler.Repositories.Interface;

namespace PushNotificationsHandler.Repositories
{
    public class InMemoryMessageRepository : IMessageRepository, IDisposable
    {
        private readonly Dictionary<Guid, IMessageModel> _cache = new Dictionary<Guid, IMessageModel>();
        private object syncObj = new object();

        public Guid AddMessage(IMessageModel messageModel)
        {
            if (messageModel.Id.HasValue)
                return messageModel.Id.Value;
            Guid newId = Guid.NewGuid();
            lock (syncObj)
            {
                _cache.Add(newId, messageModel);
                return newId;
            }
        }

        public void Dispose()
        {
            lock (syncObj)
            {
                _cache.Clear();
            }
        }
    }
}