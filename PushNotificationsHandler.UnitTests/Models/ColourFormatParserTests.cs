using System.Collections.Generic;
using NUnit.Framework;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.UnitTests.Models
{
    [TestFixture]
    public class ColourFormatParserTests
    {
        private IList<ColourFormattedPart> _result;

        [OneTimeSetUp]
        public void GivenAMessageWithOneColourFormattingBlockForEntireMessage_WhenParsed_ThenOneMessagePartReturned()
        {

            var colourFormatParser = new ColourFormatParser();
            string messageText = "{colour:#FF0000}Hello World{colour}";

            _result = colourFormatParser.GetFormattedParts(messageText);
        }

        [Test]
        public void ThenOneMessagePartReturned()
        {
            Assert.That(_result.Count, Is.EqualTo(1));
        }

        [Test]
        public void ThenExpectedRgbColourValueSetInMessagePart()
        {
            var colourFormattedPart = _result[0];
            Assert.That(colourFormattedPart.ColourRgb, Is.EqualTo("#FF0000"));
        }

        [Test]
        public void ThenExpectedPartContentValueSetInMessagePart()
        {
            var colourFormattedPart = _result[0];
            Assert.That(colourFormattedPart.PartContent, Is.EqualTo("Hello World"));
        }

    }
}