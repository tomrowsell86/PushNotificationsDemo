using System.Collections.Generic;

namespace PushNotificationsHandler.Models.Services
{
    public interface IMessageModelService
    {
        IList<IMessageModel> GetMessages();
    }
}