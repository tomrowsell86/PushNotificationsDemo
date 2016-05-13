using System;
using Moq;
using NUnit.Framework;
using PushNotificationsHandler.Controllers.Api;
using PushNotificationsHandler.Models.Api;
using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.UnitTests.Controllers
{
    [TestFixture]
    public class InboundMessageControllerTests
    {
        [Test]
        public void GivenAnInboundMessage_WhenMessageIsPassedToTheApi_ThenInboundProcessorReceivesMessage()
        {
            var messageModelFactory = new Mock<IMessageModelFactory>();
            var controller = new InboundMessagesController(messageModelFactory.Object);


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
            var messageModel = new Mock<IMessageModel>();
            messageModelFactory.Setup(mmf => mmf.CreateMessageModel(inboundMessage.MessageText)).Returns(messageModel.Object);

            controller.Post(inboundMessage);

            messageModel.Verify(mm => mm.Add());
        }
    }
}