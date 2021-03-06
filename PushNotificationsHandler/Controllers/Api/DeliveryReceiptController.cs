﻿using System;
using System.Web.Http;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Api;
using PushNotificationsHandler.Models.Services;
using PushNotificationsHandler.Repositories;
using PushNotificationsHandler.Repositories.Interface;

namespace PushNotificationsHandler.Controllers.Api
{
    public class DeliveryReceiptController : ApiController
    {
        private readonly IDeliveryNotificationRepository _repository;
        private readonly ISentMessageService _sentMessageService;

        public DeliveryReceiptController(IDeliveryNotificationRepository repository, ISentMessageService sentMessageService)
        {
            _repository = repository;
            _sentMessageService = sentMessageService;
        }

        public void Post(MessageDelivered delivery)
        {
             string sentMessageText = _sentMessageService.GetMessageText(delivery.MessageId);
            var sentMessage = new SentMessageModel
                              {
                                  MessageText = sentMessageText,
                                  MessageId = delivery.MessageId,
                                  DeliveredAt = delivery.OccurredAt,
                                  Source = new NotificationSource { BrandingColourRgb = "#42145f", Description = "Esendex" }

                              };
            _repository.Save(sentMessage);
        }

        public IHttpActionResult Get(Guid messageId, string sendNumber)
        {
            var sentMessage = new SentMessageModel
                              {
                                  Source = new NotificationSource { BrandingColourRgb = "#3B757D", Description = "Url Postbacks" }
                                  ,
                                  MessageText = "Not supported by Collstream API!"
                                  ,
                                  DeliveredAt = DateTime.UtcNow
                                  ,
                                  MessageId = messageId
                              };
            _repository.Save(sentMessage);
            return Ok();
        }
    }
}
