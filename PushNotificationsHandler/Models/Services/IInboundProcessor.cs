using PushNotificationsHandler.Models.Api;

namespace PushNotificationsHandler.Models.Services
{
    public interface IInboundProcessor
    {
        void Push(InboundMessage message);
    }
}