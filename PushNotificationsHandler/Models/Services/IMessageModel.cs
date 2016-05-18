using System;

namespace PushNotificationsHandler.Models.Services
{
    public interface IMessageModel : IFormattableContent
    {
        Guid? Id { get; }
        void Add();
        NotificationSource Source { get; }
    }

    public class NotificationSource
    {
        public string BrandingColourRgb { get; set; }
        public string Description { get; set; }
    }
}