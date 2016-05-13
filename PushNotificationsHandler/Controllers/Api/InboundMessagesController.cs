using System;
using System.Web.Http;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Api;
using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.Controllers.Api
{
    public class InboundMessagesController : ApiController
    {
        private readonly IMessageModelFactory _messageModelFactory;

        public InboundMessagesController(IMessageModelFactory messageModelFactory)
        {
            _messageModelFactory = messageModelFactory;
        }

        public void Post(InboundMessage message)
        {
            if (message == null) throw new ArgumentNullException("message");
            var messageModel =_messageModelFactory.CreateMessageModel(message.MessageText);
            messageModel.Add();
        }
    }
}