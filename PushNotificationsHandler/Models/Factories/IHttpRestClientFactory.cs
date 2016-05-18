using System;
using System.IO;
using System.Net;
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

        public EsendexRestClient(NetworkCredential credential)
        {
            _credential = credential;
        }

        public string GetTextResource(string resourcePath)
        {
            var request = WebRequest.Create(new Uri("https://api.esendex.com/v1.0/" + resourcePath));
            request.Credentials = _credential;
            
            using(var response = request.GetResponse())
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }
    }
}