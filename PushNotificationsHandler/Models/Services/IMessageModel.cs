using System;

namespace PushNotificationsHandler.Models.Services
{
    public interface IMessageModel
    {
        Guid? Id { get; }
        string PrintMessage();
        void Add();
    }
}