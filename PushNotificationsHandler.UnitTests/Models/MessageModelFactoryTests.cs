using Moq;
using NUnit.Framework;
using PushNotificationsHandler.Models.Services;
using PushNotificationsHandler.Repositories.Interface;

namespace PushNotificationsHandler.UnitTests.Models
{
    [TestFixture]
    public class MessageModelFactoryTests
    {
        private FormattedMessageModel _result;

        [SetUp]
        public void GivenAMessageModelFactory_WhenCreateCalledWithColourFormattedMessage()
        {
            var messageModelFactory = new FormattedMessageModelFactory(new ColourFormatParser(), new Mock<IMessageRepository>().Object);
            string messageText = "{colour:#00FF00}Part 1{colour} and then {colour:#00FF00}Part 2{colour} and then {colour:#00FF00}Part 3{colour}";

            _result = (FormattedMessageModel)messageModelFactory.CreateMessageModel(messageText);
        }

        [Test]
        public void ThenResultingModelContainsMessageParts()
        {
            Assert.That(_result.FormattedParts.Count, Is.EqualTo(3));
        }

        [Test]
        public void ThenModelMessageTextContainsExpectedPlaceholders()
        {
            Assert.That(_result.MessageText, Is.EqualTo("[1] and then [2] and then [3]"));
        }
    }

}