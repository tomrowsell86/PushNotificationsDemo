using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PushNotificationsHandler.Models.Services;
using PushNotificationsHandler.Repositories.Interface;

namespace PushNotificationsHandler.UnitTests.Models
{
    [TestFixture]
    public class MessageModelServiceTests
    {
        [Test]
        public void GivenAMessageModelService_WhenAllMessagesRequested_ThenExpectedMessagesReturned()
        {
            var expectedMessages = new List<IMessageModel>();
            var messageRepository = new Mock<IMessageRepository>();

            messageRepository.Setup(mr => mr.SelectAll()).Returns(expectedMessages);
            var service = new MessageModelService(messageRepository.Object);

            Assert.That(service.GetMessages(), Is.EqualTo(expectedMessages));
        }
    }
}