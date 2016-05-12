using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Api;
using PushNotificationsHandler.Models.Services;
using PushNotificationsHandler.Repositories.Interface;
using PushNotificationsHandler.UnitTests.Models.TestCaseBuilders;

namespace PushNotificationsHandler.UnitTests.Models
{
    [TestFixture]
    public class InboundProcessorWithMessagesUnFormattedMessageTests
    {
        [Test]
        public void GivenAnUnformattedMessage_WhenPushedToProcessorThenUnformattedMessagePersistedToRepository()
        {
            var formatParser = new Mock<IColourFormatParser>();
            var repository = new Mock<IMessageRepository>();
            InboundProcessor ip = new InboundProcessor(formatParser.Object, repository.Object);

            formatParser.Setup(fp => fp.GetFormattedParts(It.IsAny<string>())).Returns(new List<ColourFormattedPart>());

            MessageBuilder mb = new MessageBuilder();
            var inboundMessage = mb.CreateValidMessage("text");
            
            ip.Push(inboundMessage);

            repository.Verify(r => r.AddMessage(It.Is<MessageModel>(mm => mm.Id == inboundMessage.MessageId && mm.Text == inboundMessage.MessageText)));
        }
    }
}