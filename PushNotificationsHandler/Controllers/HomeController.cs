using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageModelService _messageModelService;

        public HomeController(IMessageModelService messageModelService)
        {
            _messageModelService = messageModelService;
        }

        public ActionResult Index()
        {
            var models = _messageModelService.GetMessages();
            return View(models);
        }
    }
}