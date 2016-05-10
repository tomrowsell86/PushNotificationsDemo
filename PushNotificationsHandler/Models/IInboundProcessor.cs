using PushNotificationsHandler.Models.Api;

namespace PushNotificationsHandler.Models
{
    public interface IInboundProcessor
    {
        void Push(InboundMessage message);
    }
}