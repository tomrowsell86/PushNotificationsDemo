using System.Web.Http;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Api;

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
            _inboundProcessor.Push(message);
        }
    }
}