using System.Collections.Generic;

namespace PushNotificationsHandler.Models.Services
{
    public interface IColourFormatParser
    {
        IList<ColourFormattedPart> GetFormattedParts(string messageText);
    }
}