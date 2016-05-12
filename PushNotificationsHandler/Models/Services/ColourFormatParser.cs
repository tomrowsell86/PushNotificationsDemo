using System;
using System.Collections.Generic;

namespace PushNotificationsHandler.Models.Services
{
    public class ColourFormatParser : IColourFormatParser
    {
        public IList<ColourFormattedPart> GetFormattedParts(string messageText)
        {
            throw new NotImplementedException();
            //Regex.Matches(messageText, @"\{colour:#[0-9A-Fa-f]{6}\}(<?messagePart>.+){colour}").Cast<Match>().Select(m => new ColourFormattedPart(m.Value, m.Groups["messagePart"]))
        }
    }
}