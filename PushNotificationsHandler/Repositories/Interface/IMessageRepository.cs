using System;
using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.Repositories.Interface
{
    public interface IMessageRepository
    {
        Guid AddMessage(IMessageModel messageModel);
    }
}