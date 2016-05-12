using System;
using PushNotificationsHandler.Models.Api;

namespace PushNotificationsHandler.UnitTests.Models.TestCaseBuilders
{
    public class MessageBuilder
    {
        public InboundMessage CreateValidMessage(string messageText)
        {
            return new InboundMessage
                   {
                       AccountId = Guid.NewGuid(),
                       From = "07752192872",
                       Id = Guid.NewGuid(),
                       MessageText = messageText,
                       MessageId = Guid.NewGuid(),
                       Now = DateTime.Now,
                       To = "0778723133"
                   };
        }
    }
}