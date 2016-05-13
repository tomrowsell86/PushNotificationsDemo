using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PushNotificationsHandler.Models.Services
{
    public class ColourFormatParser : IColourFormatParser
    {
        private const string MessagePartColourPattern = @"\{colour:(?<colour>#[0-9A-Fa-f]{6})\}(?<messagePart>.+?)\{colour\}";

        public ColourFormatParseResult FormatMessage(string messageText)
        {
            var formattedParts = new List<ColourFormattedPart>();
            var sb = new StringBuilder(messageText);
            var matches = Regex.Matches(messageText, MessagePartColourPattern).Cast<Match>().ToList();

            for (int index = matches.Count-1; index >= 0; index--)
            {
                string placeholder = "[" + (index + 1) + "]";
                var m = matches[index];

                formattedParts.Add(new ColourFormattedPart(m.Groups["colour"].Value, m.Groups["messagePart"].Value));

                sb.Remove(m.Index, m.Length);
                sb.Insert(m.Index, placeholder);
            }

            return new ColourFormatParseResult(formattedParts, sb.ToString());
        }
    }
}