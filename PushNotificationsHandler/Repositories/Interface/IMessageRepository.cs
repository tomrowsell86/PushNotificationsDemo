using System;
using System.Collections.Generic;
using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.Repositories.Interface
{
    public interface IMessageRepository
    {
        Guid AddMessage(IMessageModel messageModel);
        IList<IMessageModel> SelectAll();
    }
}