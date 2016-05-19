using System;

namespace PushNotificationsHandler.Models.Services.Exceptions
{
    public class RestApiCallException : Exception
    {
        public RestApiCallException(string message):base(message)
        {
            
        }
    }
}