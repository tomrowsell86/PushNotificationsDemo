using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Services;
using PushNotificationsHandler.Repositories;

namespace PushNotificationsHandler.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageModelService _messageModelService;
        private readonly IDeliveryNotificationRepository _repository;

        public HomeController(IMessageModelService messageModelService, IDeliveryNotificationRepository repository)
        {
            _messageModelService = messageModelService;
            _repository = repository;
        }

        public ActionResult Index()
        {
            var models = _messageModelService.GetMessages();
            return View(new IndexViewModel
                        {
                            InboundMessages = models,
                            DeliveryNotifications =_repository.GetAllDeliveredMessages().Select(d => new DeliveryNotificationModel{ Description = d.MessageText}).ToList()
                        });
        }
    }
}