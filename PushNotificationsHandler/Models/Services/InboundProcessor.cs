using System;
using System.Linq;
using PushNotificationsHandler.Models.Api;
using PushNotificationsHandler.Repositories.Interface;

namespace PushNotificationsHandler.Models.Services
{
    public class InboundProcessor : IInboundProcessor
    {
        private readonly IColourFormatParser _colourFormatParser;
        private readonly IMessageRepository _messageRepository;

        public InboundProcessor(IColourFormatParser colourFormatParser, IMessageRepository messageRepository)
        {
            _colourFormatParser = colourFormatParser;
            _messageRepository = messageRepository;
        }

        public void Push(InboundMessage message)
        {
            if (message == null) throw new ArgumentNullException("message");

            var parts = _colourFormatParser.GetFormattedParts(message.MessageText);

            _messageRepository.AddMessage(new MessageModel{Id = message.MessageId, Text = message.MessageText, Parts = parts});
        }
    }
}