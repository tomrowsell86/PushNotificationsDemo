using System.Xml.Linq;

namespace PushNotificationsHandler.Models
{
    public interface IRestClient
    {
        XElement GetResourceReponse(string resourcePath);
    }
}