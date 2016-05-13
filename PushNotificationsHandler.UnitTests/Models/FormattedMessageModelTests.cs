using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Services;
using PushNotificationsHandler.Repositories.Interface;

namespace PushNotificationsHandler.UnitTests.Models
{
    [TestFixture]
    public class FormattedMessageModelTests
    {
        private readonly Mock<IMessageRepository> _messageRepository = new Mock<IMessageRepository>();
        private FormattedMessageModel _messageModel;

        [SetUp]
        public void GivenAMessageModel_WhenAddCalled()
        {
            _messageModel = new FormattedMessageModel("A message", new List<ColourFormattedPart>(), _messageRepository.Object);
            _messageModel.Add();
        }

        [Test]
        public void ThenMessageRepositoryCalled()
        {
           _messageRepository.Verify(r => r.AddMessage(_messageModel));   
        }

        [Test]
        public void ThenMessageModelReceivesId()
        {
            Assert.That(_messageModel.Id, Is.Not.Null);
        }
    }
}