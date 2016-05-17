using System;
using System.Collections.Generic;

namespace PushNotificationsHandler.Models
{
    public class MessageModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public IList<ColourFormattableContent> Parts { get; set; }
    }
}