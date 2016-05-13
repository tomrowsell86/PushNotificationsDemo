using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Api;
using PushNotificationsHandler.Models.Services;
using PushNotificationsHandler.Repositories.Interface;

namespace PushNotificationsHandler.UnitTests.Models
{
    [TestFixture]
    public class InboundProcessorWithMessagesFormattedMessageTests
    {
        private readonly Mock<IMessageRepository> _repository = new Mock<IMessageRepository>();
        private InboundProcessor _processor;

        private readonly InboundMessage _inboundMessage = new InboundMessage
                                                          {
                                                              AccountId = Guid.NewGuid(),
                                                              From = "07752192872",
                                                              Id = Guid.NewGuid(),
                                                              MessageText = "Hello Bob",
                                                              MessageId = Guid.NewGuid(),
                                                              Now = DateTime.Now,
                                                              To = "0778723133"
                                                          };

        private readonly List<ColourFormattedPart> _formattedParts = new List<ColourFormattedPart>{ new ColourFormattedPart("#FF0000", "RedMessage",1)};

        [SetUp]
        public void GivenAnInboundMessageWithFormatting_WhenPushedToProcessor()
        {
            var formatParser = new Mock<IColourFormatParser>();
            _processor = new InboundProcessor(formatParser.Object, _repository.Object);

            formatParser.Setup(fp => fp.GetFormattedParts(_inboundMessage.MessageText)).Returns(_formattedParts);
            _processor.Push(_inboundMessage);
        }

        [Test]
        public void ThenFormattedMessagePartsPersistedToRepository()
        {
            _repository.Verify(r => r.AddMessage(It.Is<MessageModel>(mm => mm.Parts == _formattedParts)));
        }

        [Test]
        public void ThenMessagePersistedToRepository()
        {
            _repository.Verify(r => r.AddMessage(It.Is<MessageModel>(mm => mm.Id == _inboundMessage.MessageId)));
        }
    }
}