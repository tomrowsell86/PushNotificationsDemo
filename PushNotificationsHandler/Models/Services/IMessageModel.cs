using System;

namespace PushNotificationsHandler.Models.Services
{
    public interface IMessageModel : IFormattableContent
    {
        Guid? Id { get; }
        void Add();
    }
}