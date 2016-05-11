using PushNotificationsHandler.Models.Api;

namespace PushNotificationsHandler.Models
{
    public interface IInboundProcessor
    {
        void Push(InboundMessage message);
    }

    public class InboundProcessor : IInboundProcessor
    {
        public void Push(InboundMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}