using System.Collections.Generic;

namespace PushNotificationsHandler.Models.Services
{
    public interface IColourFormatParser
    {
        ColourFormatParseResult FormatMessage(string messageText);
    }

    public class ColourFormatParseResult
    {
        private readonly IList<ColourFormattableContent> _formattedParts;
        private readonly string _templatedMessage;
        public ColourFormatParseResult(IList<ColourFormattableContent> formattedParts, string templatedMessage)
        {
            _formattedParts = formattedParts;
            _templatedMessage = templatedMessage;
        }

        public IList<ColourFormattableContent> FormattedParts
        {
            get { return _formattedParts; }
        }

        public string TemplatedMessage
        {
            get { return _templatedMessage; }
        }
    }
}