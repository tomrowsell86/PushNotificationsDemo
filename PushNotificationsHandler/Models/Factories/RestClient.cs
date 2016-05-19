using System;
using System.IO;
using System.Net;
using System.Xml.Linq;
using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.Models.Factories
{
    public class RestClient : IRestClient
    {
        private readonly NetworkCredential _credential;
        private readonly ApiEndpoint _apiEndpoint;

        public RestClient(NetworkCredential credential, ApiEndpoint apiEndpoint)
        {
            _credential = credential;
            _apiEndpoint = apiEndpoint;
        }

        public XElement GetResourceReponse(string resourcePath)
        {
            var request = WebRequest.Create(new Uri(string.Format("{0}/{1}/{2}",_apiEndpoint.Uri, _apiEndpoint.Version,resourcePath)));
            request.Credentials = _credential;
            
            using(var response = request.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using(var reader = new StreamReader(responseStream))
            {
                var responseBody = XElement.Load(reader);

                return responseBody;
            }
        }
    }
}