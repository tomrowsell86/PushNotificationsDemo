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
            _messageModel = new FormattedMessageModel("A message", new List<IFormattableContent>(), _messageRepository.Object);
            _messageModel.Save();
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

    [TestFixture]
    public class FormattedMessageModelPrintTests
    {
        [Test]
        public void GivenAFormattedMessageWithFormattedParts_WhenFormatContentIsCalled_ThenPlaceholderReplaceWithExpectedHtmlFormattedElement()
        {
            string expected = "<span style='color:#FF0000'>Formatted Message Part</span> A Message";

            var repository = new Mock<IMessageRepository>();
            var formattedParts = new List<IFormattableContent>{ new ColourFormattableContent("#FF0000","Formatted Message Part")};

            var  messageModel =  new FormattedMessageModel("[1] A Message", formattedParts, repository.Object);

            var result = messageModel.FormatContent();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}