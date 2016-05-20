using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PushNotificationsHandler.Models.Services
{
    public class FormatParser : IFormatParser
    {
        private const string MessagePartColourPattern = @"\{colour:(?<colour>#[0-9A-Fa-f]{6})\}(?<messagePart>.+?)\{colour\}";

        public FormatParseResult FormatMessage(string messageText)
        {
            var formattedParts = new List<IFormattableContent>();
            var sb = new StringBuilder(messageText);
            var matches = Regex.Matches(messageText, MessagePartColourPattern);

            for (int index = matches.Count-1; index >= 0; index--)
            {
                string placeholder = "[" + (index + 1) + "]";
                var m = matches[index];

                formattedParts.Add(new ColourFormattableContent(m.Groups["colour"].Value, m.Groups["messagePart"].Value));

                sb.Remove(m.Index, m.Length);
                sb.Insert(m.Index, placeholder);
            }

            return new FormatParseResult(formattedParts, sb.ToString());
        }
    }
}