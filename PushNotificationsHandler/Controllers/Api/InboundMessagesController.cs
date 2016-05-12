using System;
using System.Web.Http;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Api;
using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.Controllers.Api
{
    public class InboundMessagesController : ApiController
    {
        private readonly IInboundProcessor _inboundProcessor;

        public InboundMessagesController(IInboundProcessor inboundProcessor)
        {
            _inboundProcessor = inboundProcessor;
        }

        public void Post(InboundMessage message)
        {
            if (message == null) throw new ArgumentNullException("message");
            _inboundProcessor.Push(message);
        }
    }
}