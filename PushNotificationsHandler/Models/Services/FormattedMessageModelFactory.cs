using PushNotificationsHandler.Repositories.Interface;

namespace PushNotificationsHandler.Models.Services
{
    public class FormattedMessageModelFactory : IMessageModelFactory
    {
        private readonly IColourFormatParser _formatParser;
        private readonly IMessageRepository _repository;

        public FormattedMessageModelFactory(IColourFormatParser formatParser, IMessageRepository repository)
        {
            _formatParser = formatParser;
            _repository = repository;
        }

        public IMessageModel CreateMessageModel(string messageText)
        {
            var parseResult = _formatParser.FormatMessage(messageText);
           
            return new FormattedMessageModel(parseResult.TemplatedMessage, parseResult.FormattedParts,_repository);
        }
    }
}