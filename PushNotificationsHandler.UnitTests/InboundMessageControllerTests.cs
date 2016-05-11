using System;
using System.Web.Http;
using Moq;
using NUnit.Framework;
using PushNotificationsHandler.Controllers.Api;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Api;

namespace PushNotificationsHandler.UnitTests
{
    [TestFixture]
    public class InboundMessageControllerTests
    {
        [Test]
        public void GivenAnInboundMessage_WhenMessageIsPassedToTheApi_ThenInboundProcessorReceivesMessage()
        {
            var inboundProcessor = new Mock<IInboundProcessor>();
            var controller = new InboundMessagesController(inboundProcessor.Object);


            var inboundMessage = new InboundMessage
                                 {
                                     AccountId = Guid.NewGuid(),
                                     From = "07752192872",
                                     Id = Guid.NewGuid(),
                                     MessageText = "Hello Bob",
                                     MessageId = Guid.NewGuid(),
                                     Now = DateTime.Now,
                                     To = "0778723133"
                                 };
            controller.Post(inboundMessage);

            inboundProcessor.Verify(ip => ip.Push(inboundMessage));
        }

        [Test]
        public void 
    }
}