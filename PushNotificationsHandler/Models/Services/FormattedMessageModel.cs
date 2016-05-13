using System.Collections.Generic;

namespace PushNotificationsHandler.Models.Services
{
    public class FormattedMessageModel : IMessageModel
    {
        private readonly string _messageText;
        private readonly IList<ColourFormattedPart> _colourFormattedParts;

        public FormattedMessageModel(string messageText, IList<ColourFormattedPart> colourFormattedParts)
        {
            _messageText = messageText;
            _colourFormattedParts = colourFormattedParts;
        }

        public void Add()
        {
            throw new System.NotImplementedException();
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