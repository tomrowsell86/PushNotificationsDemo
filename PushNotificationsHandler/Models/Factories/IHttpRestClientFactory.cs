using System;
using System.IO;
using System.Net;
using System.Xml.Linq;
using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.Models.Factories
{
    public interface IHttpRestClientFactory
    {
        IHttpRestClient Create();
    }

    public class HttpRestClientFactory : IHttpRestClientFactory
    {
        private readonly NetworkCredential _credential;

        public HttpRestClientFactory(NetworkCredential credential)
        {
            _credential = credential;
        }

        public IHttpRestClient Create()
        {
            return new EsendexRestClient(_credential);
        }
    }

    public class EsendexRestClient : IHttpRestClient
    {
        private readonly NetworkCredential _credential;
        private Uri _restEndpointUri;

        public EsendexRestClient(NetworkCredential credential)
        {
            _credential = credential;
        }

        public string GetTextResource(string resourcePath)
        {
            _restEndpointUri = new Uri("https://api.esendex.com/v1.0/");
            var uriBuilder = new UriBuilder(_restEndpointUri);
            uriBuilder.Path = resourcePath;

            var request = WebRequest.Create(uriBuilder.Uri);
            request.Credentials = _credential;
            
            using(var response = request.GetResponse())
            using (var s = response.GetResponseStream())
            {
                var responseBody = XElement.Load(s);

                var bodyTextElem = responseBody.Element("bodytext");
                if (bodyTextElem == null) 
                    throw new NullReferenceException("No body text found in response");
                return bodyTextElem.Value;
            }
        }
    }
}