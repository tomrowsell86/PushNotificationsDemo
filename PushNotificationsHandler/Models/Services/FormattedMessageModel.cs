using System;
using System.Collections.Generic;
using PushNotificationsHandler.Repositories.Interface;

namespace PushNotificationsHandler.Models.Services
{
    public class FormattedMessageModel : IMessageModel
    {
        private readonly string _messageText;
        private readonly IList<ColourFormattedPart> _colourFormattedParts;
        private readonly IMessageRepository _messageRepository;

        public FormattedMessageModel(string messageText, IList<ColourFormattedPart> colourFormattedParts, IMessageRepository messageRepository)
        {
            _messageText = messageText;
            _colourFormattedParts = colourFormattedParts;
            _messageRepository = messageRepository;
        }

        public Guid? Id { get; private set; }

        public string PrintMessage()
        {
            return MessageText;
        }

        public void Add()
        {
            Id = _messageRepository.AddMessage(this);
        }

        public IList<ColourFormattedPart> FormattedParts
        {
            get { return _colourFormattedParts; }
        }

        public string MessageText
        {
            get { return _messageText; }
        }
    }
}