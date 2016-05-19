using System;
using PushNotificationsHandler.Models.Services.Exceptions;

namespace PushNotificationsHandler.Models.Services
{
    public class SentMessageService : ISentMessageService
    {
        private readonly IRestClient _restClient;

        public SentMessageService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public string GetMessageText(Guid messageId)
        {
            var response = _restClient.GetResourceReponse(string.Format("messageheaders/{0}/body", messageId));

            var bodyTextElem = response.Element(response.GetDefaultNamespace() + "bodytext");
            if (bodyTextElem == null)
                throw new RestApiCallException(string.Format("The bodytext element was not found when requesting message body with Id{0}.", messageId));
            
            return bodyTextElem.Value;
        }
    }
}