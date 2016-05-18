using System;
using PushNotificationsHandler.Models.Factories;

namespace PushNotificationsHandler.Models.Services
{
    public class SentMessageService : ISentMessageService
    {
        private readonly IHttpRestClientFactory _restClientFactory;

        public SentMessageService(IHttpRestClientFactory restClientFactory)
        {
            _restClientFactory = restClientFactory;
        }

        public string GetMessageText(Guid messageId)
        {
            var client = _restClientFactory.Create();

            return client.GetTextResource(string.Format("messageheaders/{0}/body", messageId));
        }
    }
}