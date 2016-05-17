using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PushNotificationsHandler.Controllers;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.UnitTests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _controller;
        private readonly Mock<IMessageModelService> _messageModelService = new Mock<IMessageModelService>();
        private ViewResult _result;
        private readonly List<IMessageModel> _expectedMessageModels = new List<IMessageModel>();

        [SetUp]
        public void GivenAHomeController_WhenIndexViewRequested()
        {
            _messageModelService.Setup(mms => mms.GetMessages()).Returns(_expectedMessageModels);            
            _controller = new HomeController(_messageModelService.Object);
            
            _result = (ViewResult)_controller.Index();
        }

        [Test]
        public void ThenExpectedMessageModelsSetInViewModel()
        {
            var model = (IndexViewModel)_result.Model;
            Assert.That(model.InboundMessages, Is.EqualTo(_expectedMessageModels));
        }
    }
}