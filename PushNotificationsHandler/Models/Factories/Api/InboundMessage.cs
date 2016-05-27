using System;
using System.Runtime.Serialization;

namespace PushNotificationsHandler.Models.Api
{
    [DataContract(Namespace = "")]
    public class InboundMessage
    {
        [DataMember]
        public string MessageText { get; set; }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid MessageId { get; set; }

        [DataMember]
        public Guid AccountId { get; set; }

        [DataMember]
        public string From { get; set; }

        [DataMember]
        public string To { get; set; }

        [DataMember]
        public DateTime Now { get; set; }
    }
}