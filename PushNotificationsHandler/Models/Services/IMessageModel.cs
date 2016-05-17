using System;

namespace PushNotificationsHandler.Models.Services
{
    public interface IMessageModel : IFormattableContent
    {
        Guid? Id { get; }
        void Add();
        MessageSource Source { get; }
    }

    public class MessageSource
    {
        public string BrandingColourRgb { get; set; }
        public string Description { get; set; }
    }
}