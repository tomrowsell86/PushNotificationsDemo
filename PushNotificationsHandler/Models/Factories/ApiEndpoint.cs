using System;

namespace PushNotificationsHandler.Models.Factories
{
    public class ApiEndpoint
    {
        private readonly string _apiVersion;
        private readonly Uri _apiUrl;

        public ApiEndpoint(string version, Uri hostUri)
        {
            _apiVersion = version;
            _apiUrl = hostUri;
        }

        public string Version
        {
            get { return _apiVersion; }
        }

        public Uri Uri
        {
            get { return _apiUrl; }
        }
    }
}