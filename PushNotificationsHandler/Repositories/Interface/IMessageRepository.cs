using System.Collections.Generic;
using PushNotificationsHandler.Models;

namespace PushNotificationsHandler.Repositories.Interface
{
    public interface IMessageRepository
    {
        void AddMessageParts(IList<ColourFormattedPart> formattedParts);
        void AddMessage(MessageModel messageModel);
    }
}