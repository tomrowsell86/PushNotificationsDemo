using System;
using System.Net;
using System.Xml.Linq;
using PushNotificationsHandler.Controllers.Api;

namespace PushNotificationsHandler.Models.Services
{
    public interface ISentMessageService
    {
        string GetMessageText(Guid messageId);
    }
}