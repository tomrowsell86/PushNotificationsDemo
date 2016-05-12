using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PushNotificationsHandler.Models.Services
{
    public class ColourFormatParser : IColourFormatParser
    {
        private const string MessagePartColourPattern = @"\{colour:(?<colour>#[0-9A-Fa-f]{6})\}(?<messagePart>.+?)\{colour\}";

        public IList<ColourFormattedPart> GetFormattedParts(string messageText)
        {
            return Regex.Matches(messageText, MessagePartColourPattern)
                .Cast<Match>()
                .Select(m => new ColourFormattedPart(m.Groups["colour"].Value, m.Groups["messagePart"].Value))
                .ToList();
        }
    }
}