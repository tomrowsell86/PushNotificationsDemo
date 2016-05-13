namespace PushNotificationsHandler.Models.Services
{
    public class FormattedMessageModelFactory : IMessageModelFactory
    {
        private readonly IColourFormatParser _formatParser;

        public FormattedMessageModelFactory(IColourFormatParser formatParser)
        {
            _formatParser = formatParser;
        }

        public IMessageModel CreateMessageModel(string messageText)
        {
            var parseResult = _formatParser.FormatMessage(messageText);
           
            return new FormattedMessageModel(parseResult.TemplatedMessage, parseResult.FormattedParts);
        }
    }
}