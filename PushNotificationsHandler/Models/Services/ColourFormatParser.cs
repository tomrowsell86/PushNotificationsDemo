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
            List<ColourFormattedPart> list = new List<ColourFormattedPart>();
            var matches = Regex.Matches(messageText, MessagePartColourPattern).Cast<Match>().ToList();

            for (int index = 0, ordinal = 1; index < matches.Count; index++,ordinal++)
            {
                var m = matches[index];
                list.Add(new ColourFormattedPart(m.Groups["colour"].Value, m.Groups["messagePart"].Value, ordinal));
            }
            return list;
        }
    }
}