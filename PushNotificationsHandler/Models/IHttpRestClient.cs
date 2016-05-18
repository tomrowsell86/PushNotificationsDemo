namespace PushNotificationsHandler.Models
{
    public interface IHttpRestClient
    {
        string GetTextResource(string resourcePath);
    }
}