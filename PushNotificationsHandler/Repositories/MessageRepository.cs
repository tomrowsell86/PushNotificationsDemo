using System;
using PushNotificationsHandler.Models.Services;
using PushNotificationsHandler.Repositories.Interface;

namespace PushNotificationsHandler.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public Guid AddMessage(IMessageModel messageModel)
        {
            throw new System.NotImplementedException();
        }
    }
}