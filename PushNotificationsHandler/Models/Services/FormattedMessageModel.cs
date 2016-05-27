using System;
using System.Collections.Generic;
using System.Text;
using PushNotificationsHandler.Repositories.Interface;

namespace PushNotificationsHandler.Models.Services
{
    public class FormattedMessageModel : IMessageModel
    {
        private readonly string _messageText;
        private readonly IList<IFormattableContent> _colourFormattedParts;
        private readonly IMessageRepository _messageRepository;

        public FormattedMessageModel(string messageText, IList<IFormattableContent> colourFormattedParts, IMessageRepository messageRepository)
        {
            _messageText = messageText;
            _colourFormattedParts = colourFormattedParts;
            _messageRepository = messageRepository;
        }

        public Guid? Id { get; private set; }

        public void Save()
        {
            Id = _messageRepository.AddMessage(this);
        }

        public NotificationSource Source { get; set; }

        public IList<IFormattableContent> FormattedParts
        {
            get { return _colourFormattedParts; }
        }

        public string MessageText
        {
            get { return _messageText; }
        }

        public string FormatContent()
        {
            var messageBuilder = new StringBuilder(MessageText);
            for (int index = 0, partIndex = 1; index < FormattedParts.Count; index++, partIndex++)
            {
                messageBuilder.Replace("[" + partIndex + "]", FormattedParts[index].FormatContent());
            }
            return messageBuilder.ToString();
        }
    }
}