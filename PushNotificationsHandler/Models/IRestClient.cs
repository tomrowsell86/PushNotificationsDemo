using System.Xml.Linq;

namespace PushNotificationsHandler.Models
{
    public interface IRestClient
    {
        XElement GetResourceReponseAsXml(string resourcePath);
    }
}