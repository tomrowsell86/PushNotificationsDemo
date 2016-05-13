namespace PushNotificationsHandler.Models.Services
{
    public interface IMessageModelFactory
    {
        IMessageModel CreateMessageModel(string messageText);
    }
}