using System.Collections.Generic;

namespace PushNotificationsHandler.Models.Services
{
    public interface IFormatParser
    {
        FormatParseResult FormatMessage(string messageText);
    }

    public class FormatParseResult
    {
        private readonly IList<IFormattableContent> _formattedParts;
        private readonly string _templatedMessage;
        public FormatParseResult(IList<IFormattableContent> formattedParts, string templatedMessage)
        {
            _formattedParts = formattedParts;
            _templatedMessage = templatedMessage;
        }

        public IList<IFormattableContent> FormattedParts
        {
            get { return _formattedParts; }
        }

        public string TemplatedMessage
        {
            get { return _templatedMessage; }
        }
    }
}