using System;
using System.Runtime.Serialization;

namespace PushNotificationsHandler.Models.Api
{
     [DataContract(Namespace = "")]
    public class MessageDelivered
    {
         [DataMember]
         public Guid Id { get; set; }

         [DataMember]
         public Guid MessageId { get; set; }

         [DataMember]
         public Guid AccountId { get; set; }

         public DateTime OccurredAt { get; set; }
    }
}